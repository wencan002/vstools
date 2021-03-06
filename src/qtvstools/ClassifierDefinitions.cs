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

#if VS2013
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace QtVsTools
{
    class ClassifierDefinitions
    {
        [Name(ClassifierTypes.Comment), Export]
        internal ClassificationTypeDefinition CommentClassifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = ClassifierTypes.Comment)]
        [Name("CommentFormatDefinition")]
        [Order]
        internal sealed class CommentFormatDefinition : ClassificationFormatDefinition
        {
            /// <summary>
            /// Defines the visual format for the "Comment" classification type
            /// </summary>
            internal CommentFormatDefinition()
            {
                // ARGB value: #FF008000
                ForegroundColor = Colors.Green;
                DisplayName = "QML Comment"; //human readable version of the name
            }
        }

        [Name(ClassifierTypes.Keyword), Export]
        internal ClassificationTypeDefinition KeywordClassifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = ClassifierTypes.Keyword)]
        [Name("KeywordFormatDefinition")]
        [Order]
        internal sealed class KeywordFormatDefinition : ClassificationFormatDefinition
        {
            /// <summary>
            /// Defines the visual format for the "Keyword" classification type
            /// </summary>
            internal KeywordFormatDefinition()
            {
                // ARGB value: #FF808000
                ForegroundColor = Colors.Olive;
                DisplayName = "QML Keyword"; //human readable version of the name
            }
        }

        [Name(ClassifierTypes.Property), Export]
        internal ClassificationTypeDefinition PropertyClassifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = ClassifierTypes.Property)]
        [Name("PropertyFormatDefinition")]
        [Order]
        internal sealed class PropertyFormatDefinition : ClassificationFormatDefinition
        {
            /// <summary>
            /// Defines the visual format for the "Property" classification type
            /// </summary>
            internal PropertyFormatDefinition()
            {
                // ARGB value: #FF808000
                ForegroundColor = Colors.Olive;
                DisplayName = "QML Property"; //human readable version of the name
            }
        }

        [Name(ClassifierTypes.JsKeyword), Export]
        internal ClassificationTypeDefinition JsKeywordClassifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = ClassifierTypes.JsKeyword)]
        [Name("JsKeywordFormatDefinition")]
        [Order]
        internal sealed class JsKeywordFormatDefinition : ClassificationFormatDefinition
        {
            /// <summary>
            /// Defines the visual format for the "JS Keyword" classification type
            /// </summary>
            internal JsKeywordFormatDefinition()
            {
                // ARGB value: #FF808000
                ForegroundColor = Colors.Olive;
                DisplayName = "QML JS Keyword"; //human readable version of the name
            }
        }

        [Name(ClassifierTypes.Type), Export]
        internal ClassificationTypeDefinition TypeClassifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = ClassifierTypes.Type)]
        [Name("TypeFormatDefinition")]
        [Order]
        internal sealed class TypeFormatDefinition : ClassificationFormatDefinition
        {
            /// <summary>
            /// Defines the visual format for the "Type" classification type
            /// </summary>
            internal TypeFormatDefinition()
            {
                // ARGB value: #FF800080
                ForegroundColor = Colors.Purple;
                DisplayName = "QML Type"; //human readable version of the name
            }
        }

        [Name(ClassifierTypes.String), Export]
        internal ClassificationTypeDefinition StringClassifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = ClassifierTypes.String)]
        [Name("StringFormatDefinition")]
        [Order]
        internal sealed class StringFormatDefinition : ClassificationFormatDefinition
        {
            /// <summary>
            /// Defines the visual format for the "String" classification type
            /// </summary>
            internal StringFormatDefinition()
            {
                // ARGB value: #FF800000
                ForegroundColor = Colors.Maroon;
                DisplayName = "QML String"; //human readable version of the name
            }
        }

        [Name(ClassifierTypes.Other), Export]
        internal ClassificationTypeDefinition OtherClassifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = ClassifierTypes.Other)]
        [Name("OtherFormatDefinition")]
        [Order]
        internal sealed class OtherFormatDefinition : ClassificationFormatDefinition
        {
            /// <summary>
            /// Defines the visual format for the "Other" classification type
            /// </summary>
            internal OtherFormatDefinition()
            {
                DisplayName = "QML Other"; //human readable version of the name
            }
        }
    }
}
#endif
