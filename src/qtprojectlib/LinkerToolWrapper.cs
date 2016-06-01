/****************************************************************************
**
** Copyright (C) 2016 The Qt Company Ltd.
** Contact: https://www.qt.io/licensing/
**
** This file is part of the Qt VS Tools.
**
** $QT_BEGIN_LICENSE:GPL-EXCEPT$
** Commercial License Usage
** Licensees holding valid commercial Qt licenses may use this file in
** accordance with the commercial license agreement provided with the
** Software or, alternatively, in accordance with the terms contained in
** a written agreement between you and The Qt Company. For licensing terms
** and conditions see https://www.qt.io/terms-conditions. For further
** information use the contact form at https://www.qt.io/contact-us.
**
** GNU General Public License Usage
** Alternatively, this file may be used under the terms of the GNU
** General Public License version 3 as published by the Free Software
** Foundation with exceptions as appearing in the file LICENSE.GPL3-EXCEPT
** included in the packaging of this file. Please review the following
** information to ensure the GNU General Public License requirements will
** be met: https://www.gnu.org/licenses/gpl-3.0.html.
**
** $QT_END_LICENSE$
**
****************************************************************************/

using Microsoft.VisualStudio.VCProjectEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace QtProjectLib
{
    /// <summary>
    /// Adds convenience functions to the VCLinkerTool.
    /// </summary>
    public class LinkerToolWrapper
    {
        private VCLinkerTool linker;

        public LinkerToolWrapper(VCLinkerTool linkerTool)
        {
            linker = linkerTool;
        }

        public List<string> AdditionalLibraryDirectories
        {
            get
            {
                if (linker.AdditionalLibraryDirectories == null)
                    return null;
                string[] dirArray = linker.AdditionalLibraryDirectories.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> lst = new List<string>(dirArray);
                for (int i = 0; i < lst.Count; ++i) {
                    string item = lst[i];
                    if (item.StartsWith("\"") && item.EndsWith("\"")) {
                        item = item.Remove(0, 1);
                        item = item.Remove(item.Length - 1, 1);
                        lst[i] = item;
                    }
                }
                return lst;
            }

            internal set
            {
                if (value == null) {
                    linker.AdditionalLibraryDirectories = null;
                    return;
                }

                string newAdditionalLibraryDirectories = "";
                bool firstLoop = true;
                foreach (string item in value) {
                    if (firstLoop)
                        firstLoop = false;
                    else
                        newAdditionalLibraryDirectories += ";";

                    if (!Path.IsPathRooted(item) || item.IndexOfAny(new char[] { ' ', '\t' }) > 0)
                        newAdditionalLibraryDirectories += "\"" + item + "\"";
                    else
                        newAdditionalLibraryDirectories += item;
                }
                if (newAdditionalLibraryDirectories != linker.AdditionalLibraryDirectories)
                    linker.AdditionalLibraryDirectories = newAdditionalLibraryDirectories;
            }
        }

        public List<string> AdditionalDependencies
        {
            get
            {
                if (linker.AdditionalDependencies == null)
                    return null;
                return splitByWhitespace(linker.AdditionalDependencies);
            }

            internal set
            {
                if (value == null) {
                    linker.AdditionalDependencies = null;
                    return;
                }

                string newAdditionalDependencies = "";
                char[] separators = new char[] { ' ', '\t' };
                bool firstLoop = true;
                foreach (string item in value) {
                    if (firstLoop)
                        firstLoop = false;
                    else
                        newAdditionalDependencies += " ";

                    int idx = item.IndexOfAny(separators);
                    if (idx >= 0)
                        newAdditionalDependencies += "\"" + item + "\"";
                    else
                        newAdditionalDependencies += item;
                }
                if (newAdditionalDependencies != linker.AdditionalDependencies)
                    linker.AdditionalDependencies = newAdditionalDependencies;
            }
        }

        /// <summary>
        /// Splits a given string by whitespace characters and takes care of double quotes.
        /// </summary>
        /// <param name="str">string to be split</param>
        /// <returns></returns>
        private static List<string> splitByWhitespace(string str)
        {
            char[] separators = new char[] { ' ', '\t' };
            int i = str.IndexOf('"');
            if (i == -1)
                return new List<string>(str.Split(separators, StringSplitOptions.RemoveEmptyEntries));

            List<string> ret = new List<string>();
            int startIndex = 0;
            Regex r = new Regex(@"""[^""]*""");
            MatchCollection mc = r.Matches(str);
            foreach (Match match in mc) {
                string item = match.Value;
                item = item.Remove(0, 1);
                item = item.Remove(item.Length - 1, 1);

                // Add all items before this match, using standard splitting.
                string strBefore = str.Substring(startIndex, match.Index - startIndex);
                string[] lstBefore = strBefore.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                ret.AddRange(lstBefore);
                startIndex = match.Index + match.Length;

                if (item.Length == 0)
                    continue;

                ret.Add(item);
            }

            if (startIndex < str.Length - 1) {
                // Add all items after the quoted match, using standard splitting.
                string strBefore = str.Substring(startIndex);
                string[] lstBefore = strBefore.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                ret.AddRange(lstBefore);
            }

            return ret;
        }

    }
}
