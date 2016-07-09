﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ClockMarkRenderer : RendererBase
    {
        private readonly List<vec3> markPosition = new List<vec3>();
        private readonly List<vec3> markColor = new List<vec3>();

        protected override void DoInitialize()
        {
            int markCount = 60;
            for (int i = 0; i < markCount; i++)
            {
                var position = new vec3(
                    (float)Math.Cos((double)i / (double)markCount * Math.PI * 2),
                    (float)Math.Sin((double)i / (double)markCount * Math.PI * 2),
                    0);
                markPosition.Add(position);
                markColor.Add(new vec3(1, 1, 1));

                var position2 = new vec3(
                    (float)Math.Cos((double)i / (double)markCount * Math.PI * 2),
                    (float)Math.Sin((double)i / (double)markCount * Math.PI * 2),
                    0) * (i % 5 == 0 ? 0.8f : 0.9f);
                markPosition.Add(position2);
                markColor.Add(new vec3(1, 1, 1));
            }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            OpenGL.LoadIdentity();
            OpenGL.Begin(DrawMode.Lines);
            for (int i = 0; i < markPosition.Count; i++)
            {
                vec3 color = markColor[i];
                OpenGL.Color3f(color.x, color.y, color.z);
                vec3 position = markPosition[i];
                OpenGL.Vertex3f(position.x, position.y, position.z);
            }
            OpenGL.End();
        }

    }
}
