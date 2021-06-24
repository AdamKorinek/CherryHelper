﻿using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.CherryHelper
{
    [CustomEntity("CherryHelper/AssistRect")]
    public class AssistRectangle : Entity
    {

        public Color color = Color.White;

        public float secretAlpha = 0.25f;
        public AssistRectangle(Vector2 position, int width, int height, Color color)
        {
            Position = position;
            Collider = new Hitbox(width, height);
            this.color = color;
        }
        public AssistRectangle(EntityData data, Vector2 offset) : this(data.Position + offset, data.Width, data.Height, Calc.HexToColor(data.Attr("color")))
        {

        }
        public override void Render()
        {
            int num = (int)Left;
            int num2 = (int)Right;
            int num3 = (int)Top;
            int num4 = (int)Bottom;
            Draw.Rect(num + 4, num3 + 4, Width - 8f, Height - 8f, color * secretAlpha);
            for (float num5 = num; num5 < (float)(num2 - 3); num5 += 3f)
            {
                Draw.Line(num5, num3, num5 + 2f, num3, color);
                Draw.Line(num5, num4 - 1, num5 + 2f, num4 - 1, color);
            }
            for (float num6 = num3; num6 < (float)(num4 - 3); num6 += 3f)
            {
                Draw.Line(num + 1, num6, num + 1, num6 + 2f, color);
                Draw.Line(num2, num6, num2, num6 + 2f, color);
            }
            Draw.Rect(num + 1, num3, 1f, 2f, color);
            Draw.Rect(num2 - 2, num3, 2f, 2f, color);
            Draw.Rect(num, num4 - 2, 2f, 2f, color);
            Draw.Rect(num2 - 2, num4 - 2, 2f, 2f, color);
            base.Render();
        }
    }
}
