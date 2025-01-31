/*
 * Copyright (C) 2011 D3Sharp Project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Text;

using D3Sharp.Core.NPC;
using D3Sharp.Core.Helpers;
using D3Sharp.Net.Game.Message.Definitions.Animation;
using D3Sharp.Net.Game.Message.Definitions.Attribute;
using D3Sharp.Net.Game.Message.Definitions.Effect;
using D3Sharp.Net.Game.Message.Definitions.Misc;
using D3Sharp.Net.Game.Message.Fields;
using D3Sharp.Net.Game.Messages;

namespace D3Sharp.Net.Game.Message.Definitions.Animation
{
    [IncomingMessage(Opcodes.SecondaryAnimationPowerMessage)]
    public class SecondaryAnimationPowerMessage : GameMessage
    {
        public int /* sno */ snoPower;
        public AnimPreplayData Field1;

        public override void Handle(GameClient client)
        {

            
        }

        public override void Parse(GameBitBuffer buffer)
        {
            snoPower = buffer.ReadInt(32);
            if (buffer.ReadBool())
            {
                Field1 = new AnimPreplayData();
                Field1.Parse(buffer);
            }
        }

        public override void Encode(GameBitBuffer buffer)
        {
            buffer.WriteInt(32, snoPower);
            buffer.WriteBool(Field1 != null);
            if (Field1 != null)
            {
                Field1.Encode(buffer);
            }
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("SecondaryAnimationPowerMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("snoPower: 0x" + snoPower.ToString("X8"));
            if (Field1 != null)
            {
                Field1.AsText(b, pad);
            }
            b.Append(' ', --pad);
            b.AppendLine("}");
        }
    }

}