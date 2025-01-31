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
using D3Sharp.Net.Game.Message.Fields;
using D3Sharp.Net.Game.Messages;

namespace D3Sharp.Net.Game.Message.Definitions.ACD
{
    public class ACDTranslateSnappedMessage : GameMessage
    {
        public int Field0;
        public Vector3D Field1;
        public float /* angle */ Field2;
        public bool Field3;
        public int Field4;


        public override void Handle(GameClient client)
        {
            throw new NotImplementedException();
        }

        public override void Parse(GameBitBuffer buffer)
        {
            Field0 = buffer.ReadInt(32);
            Field1 = new Vector3D();
            Field1.Parse(buffer);
            Field2 = buffer.ReadFloat32();
            Field3 = buffer.ReadBool();
            Field4 = buffer.ReadInt(24);
        }

        public override void Encode(GameBitBuffer buffer)
        {
            buffer.WriteInt(32, Field0);
            Field1.Encode(buffer);
            buffer.WriteFloat32(Field2);
            buffer.WriteBool(Field3);
            buffer.WriteInt(24, Field4);
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("ACDTranslateSnappedMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("Field0: 0x" + Field0.ToString("X8"));
            Field1.AsText(b, pad);
            b.Append(' ', pad); b.AppendLine("Field2: " + Field2.ToString("G"));
            b.Append(' ', pad); b.AppendLine("Field3: " + (Field3 ? "true" : "false"));
            b.Append(' ', pad); b.AppendLine("Field4: 0x" + Field4.ToString("X8") + " (" + Field4 + ")");
            b.Append(' ', --pad);
            b.AppendLine("}");
        }


    }
}