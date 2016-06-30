﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public partial class CodedColorValueRenderer : Renderer
    {

        private TextModel textModel;

        public FontResource FontResource { get; set; }

        private string content = string.Empty;
        public string Text
        {
            get { return content; }
            set
            {
                if (this.textModel != null) { this.textModel.SetText(value, this.FontResource); }
                this.content = value;
            }
        }


        public CodedColorValueRenderer(TextModel textModel, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(textModel, shaderCodes, propertyNameMap, switches)
        {
            this.textModel = textModel;
            this.FontResource = FontResource.Default;
        }

    }
}