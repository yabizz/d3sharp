using System.Text;
using D3Sharp.Net.Game.Messages;

namespace D3Sharp.Net.Game.Message.Fields
{
    public class SceneCachedValues
    {
        public int Field0;
        public int Field1;
        public int Field2;
        public AABB Field3;
        public AABB Field4;
        // MaxLength = 4
        public int[] Field5;
        public int Field6;

        public void Parse(GameBitBuffer buffer)
        {
            Field0 = buffer.ReadInt(32);
            Field1 = buffer.ReadInt(32);
            Field2 = buffer.ReadInt(32);
            Field3 = new AABB();
            Field3.Parse(buffer);
            Field4 = new AABB();
            Field4.Parse(buffer);
            Field5 = new int[4];
            for (int i = 0; i < Field5.Length; i++) Field5[i] = buffer.ReadInt(32);
            Field6 = buffer.ReadInt(32);
        }

        public void Encode(GameBitBuffer buffer)
        {
            buffer.WriteInt(32, Field0);
            buffer.WriteInt(32, Field1);
            buffer.WriteInt(32, Field2);
            Field3.Encode(buffer);
            Field4.Encode(buffer);
            for (int i = 0; i < Field5.Length; i++) buffer.WriteInt(32, Field5[i]);
            buffer.WriteInt(32, Field6);
        }

        public void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("SceneCachedValues:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad);
            b.AppendLine("Field0: 0x" + Field0.ToString("X8") + " (" + Field0 + ")");
            b.Append(' ', pad);
            b.AppendLine("Field1: 0x" + Field1.ToString("X8") + " (" + Field1 + ")");
            b.Append(' ', pad);
            b.AppendLine("Field2: 0x" + Field2.ToString("X8") + " (" + Field2 + ")");
            Field3.AsText(b, pad);
            Field4.AsText(b, pad);
            b.Append(' ', pad);
            b.AppendLine("Field5:");
            b.Append(' ', pad);
            b.AppendLine("{");
            for (int i = 0; i < Field5.Length;)
            {
                b.Append(' ', pad + 1);
                for (int j = 0; j < 8 && i < Field5.Length; j++, i++)
                {
                    b.Append("0x" + Field5[i].ToString("X8") + ", ");
                }
                b.AppendLine();
            }
            b.Append(' ', pad);
            b.AppendLine("}");
            b.AppendLine();
            b.Append(' ', pad);
            b.AppendLine("Field6: 0x" + Field6.ToString("X8") + " (" + Field6 + ")");
            b.Append(' ', --pad);
            b.AppendLine("}");
        }


    }
}