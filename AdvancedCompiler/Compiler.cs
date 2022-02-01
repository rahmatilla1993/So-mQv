using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedCompiler
{
    class Compiler
    {
        List<string> address = new List<string>();
        List<string> label = new List<string>();

        public void SetFirstAddress(string address)
        {
            this.address.Add(address);
        }
        public void SetLabelElements(string label)
        {
            this.label.Add(label);
        }
        public void RemoveListsElements()
        {
            k = 0;
            address.Clear();
            label.Clear();
        }
        private string GetMachineCode(string command)
        {
            string str = "";
            switch(command)
            {
                case "STL":     str += "14";break;
                case "JSUB":    str += "48";break;
                case "LDA":     str += "00";break;
                case "COMP":    str += "28";break;
                case "JEQ":     str += "30";break;
                case "J":       str += "3C";break;
                case "STA":     str += "0C";break;
                case "LDL":     str += "08";break;
                case "LDX":     str += "04";break;
                case "TD":      str += "E0";break;
                case "RD":      str += "D8";break;
                case "STCH":    str += "54";break;
                case "JLT":     str += "38";break;
                case "STX":     str += "10";break;
                case "LDCH":    str += "50";break;
                case "RSUB":    str += "4C";break;
                case "TIX":     str += "2C";break;
            }
            return str;
        }
        private string ManipulationOfBits(string MCode, string operand)
        {
            int dec = Convert.ToInt32(MCode);
            string binary = Convert.ToString(dec, 2);
            char[] binChar = binary.ToCharArray();

            if (operand.StartsWith("#"))
            {
                binChar[7] = '1';
            }

            else if (operand.StartsWith("@"))
            {
                binChar[6] = '1';
                binChar[10] = '1';
            }

            else
            {
                binChar[6] = '1';
                binChar[7] = '1';
                binChar[10] = '1';
            }
            
            binary = new string(binChar);
            return Convert.ToString(Convert.ToInt32(binary, 2), 16);
        }
        public string CreateObjectCode(string command, string operand, int index)
        {
            string ObCode = GetMachineCode(command);
            if (command.Equals("STL") || command.Equals("JSUB") || command.Equals("LDA") || command.Equals("COMP") || command.Equals("JEQ") || command.Equals("J") ||
                command.Equals("STA") || command.Equals("LDL") || command.Equals("LDX") || command.Equals("TD") || command.Equals("RD") || command.Equals("STCH") ||
                command.Equals("JLT") || command.Equals("STX") || command.Equals("LDCH") || command.Equals("RSUB") || command.Equals("TIX"))
            {
                if (operand.Equals(""))
                    ObCode += "000";

                else if (char.IsDigit(operand[0]) || char.IsDigit(operand[1]))
                {
                    ObCode = ManipulationOfBits(ObCode, operand);
                    string s = "";
                    if (char.IsDigit(operand[0]))
                    {
                        s = operand.Substring(0);
                    }
                    else
                    {
                        s = operand.Substring(1);
                    }
                    int n = Convert.ToInt32(s);
                    s = Convert.ToString(n, 16);

                    for (int i = s.Length; i < 3; i++)
                    {
                        s = "0" + s;
                    }
                    ObCode += s;
                }

                else
                {
                    ObCode = ManipulationOfBits(ObCode, operand);
                    string str = "";
                    for (int i = 0; i < label.Count; i++)
                    {
                        if (operand.Equals(label[i]))
                        {
                            int a = Convert.ToInt32(address[i], 16);
                            int b = Convert.ToInt32(address[index + 1], 16);
                            str = Convert.ToString(a - b, 16);
                            if(str.Length > 3)
                            {
                                str = str.Substring(4);
                            }
                            else
                            {
                                for (int j = str.Length; j < 3; j++)
                                    str = "0" + str;
                            }
                            break;
                        }
                    }
                    ObCode += str;
                }
            }

            ObCode = ObCode.ToUpper();
            return ObCode;
        }

        int k = 0;
        public string GetAddress(string cmd, string opernd)
        {
            int dec = Convert.ToInt32(address[k], 16);
            if (cmd.StartsWith("+"))
            {
                dec += 4;
            }
            else if(cmd == "STL" || cmd == "JSUB" || cmd == "LDA" || cmd == "COMP" || cmd == "JEQ" || cmd == "J" || cmd == "STA" || cmd == "LDL" || cmd == "RSUB"
                || cmd == "LDX" || cmd == "TD" || cmd == "RD" || cmd == "STCH" || cmd == "TIX" || cmd == "JLT" || cmd == "STX" || cmd == "LDCH" || cmd == "WORD")
            {
                dec += 3;
            }
            else
            {
                if (cmd.Equals("BYTE"))
                {
                    string str = opernd.Substring(opernd.IndexOf("'") + 1, opernd.LastIndexOf("'") - 2);
                    if (opernd.StartsWith("C"))
                    {
                        dec += str.Length;
                    }
                    else
                    {
                        if (str.Length % 2 == 1)
                            dec += str.Length / 2 + 1;
                        else
                            dec += str.Length / 2;

                    }
                }

                else if (cmd.Equals("RESB"))
                {
                    dec += Convert.ToInt32(opernd);
                }
                else if (cmd.Equals("RESW"))
                {
                    dec += Convert.ToInt32(opernd) * 3;
                }
            }
            address.Add(Convert.ToString(dec, 16).ToUpper());
            return address[++k];
        }
    }
}
