﻿using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterBackgroundRenderer : Renderer
    {
        public float passedTime;

        public static WaterBackgroundRenderer Create(int waterPlaneLength)
        {
            var model = new Sphere(waterPlaneLength / 2.0f + 0.5f, 20, 80);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\Background.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\Background.frag.glsl"), ShaderType.FragmentShader);
            var provider = new ShaderCodeArray(shaderCodes);
            var map = new AttributeMap();
            map.Add("a_vertex", PlaneModel.strPosition);
            //map.Add("a_normal", PlaneModel.strNormal);
            var renderer = new WaterBackgroundRenderer(model, provider, map, new FrontFaceState(FrontFaceMode.CW));
            renderer.ModelSize = new vec3(waterPlaneLength + 1, waterPlaneLength + 1, waterPlaneLength + 1);

            return renderer;
        }

        private WaterBackgroundRenderer(
            IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
        }
    }
}