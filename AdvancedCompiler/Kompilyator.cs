using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AdvancedCompiler
{
    class Kompilyator
    {
        List<string> address = new List<string>();
        List<string> label = new List<string>();
        List<string> commands = new List<string>();
        int k = 0;

        public void SetListsElements(string label, string command)
        {
            this.label.Add(label);
            commands.Add(command);
        }
        public void RemoveListsElements()
        {
            k = 0;
            address.Clear();
            label.Clear();
            commands.Clear();
        }
        public void SetFirstAddress(string address)
        {
            this.address.Add(address);
            commands.Add("");
        }
        public string GetAddress(string opernd, string cmd)
        {
            int dec = Convert.ToInt32(address[k], 16);
            if (cmd.StartsWith("+"))
            {
                dec += 4;
            }
            else if (cmd == "STL" || cmd == "JSUB" || cmd == "LDA" || cmd == "COMP" || cmd == "JEQ" || cmd == "J" || cmd == "STA" || cmd == "LDL" || cmd == "RSUB"
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
                else if (cmd.StartsWith("=C"))
                {
                    int m = cmd.IndexOf("'") + 1;
                    string str = cmd.Substring(m, cmd.LastIndexOf("'") - m);
                    dec += str.Length;
                }
                else
                {
                    int m = cmd.IndexOf("'") + 1;
                    string str = cmd.Substring(m, cmd.LastIndexOf("'") - m);
                    foreach(char c in str)
                    {
                        if (!(c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' ||
                            c == 'A' || c == 'B' || c == 'C' || c == 'D' || c == 'E' || c == 'F'))
                        {
                            MessageBox.Show("Faqat 16likdagi sonlar kiritiladi!");
                            Application.Exit();
                        }
                    }
                    if (str.Length % 2 == 1)
                        dec += str.Length / 2 + 1;
                    else
                        dec += str.Length / 2;
                }
            }
            address.Add(Convert.ToString(dec, 16).ToUpper());
            return address[++k];
        }
        private string GetMachineCode(string command)
        {
            string str = "";
            switch (command)
            {
                case "STL":     str += "14"; break;
                case "JSUB":    str += "48"; break;
                case "LDA":     str += "00"; break;
                case "COMP":    str += "28"; break;
                case "JEQ":     str += "30"; break;
                case "J":       str += "3C"; break;
                case "STA":     str += "0C"; break;
                case "LDL":     str += "08"; break;
                case "LDX":     str += "04"; break;
                case "TD":      str += "E0"; break;
                case "RD":      str += "D8"; break;
                case "STCH":    str += "54"; break;
                case "JLT":     str += "38"; break;
                case "STX":     str += "10"; break;
                case "LDCH":    str += "50"; break;
                case "RSUB":    str += "4C"; break;
                case "TIX":     str += "2C"; break;
            }
            return str;
        }
        private string HelperToObjectCode(int dec, string operand)
        {
            string str = Convert.ToString(dec, 16);

            if (operand.Contains(",X"))
            {
                str += "A";
            }
           
            else
            {
                str += "2";
            }
            for (int i = str.Length; i < 3; i++)
                str = "0" + str;
            return str;
        }
        private string HelperToObjectCode1(int dec, string operand)
        {
            string str = Convert.ToString(dec, 16);

            if (operand.Contains(",X"))
            {
                str += "9";
            }
            else
            {
                str += "1";
            }
            
            return str;
        }
        private string CreateDispose(string operand, int index)
        {
            string s = "";
            for (int i = 0; i < label.Count; i++)
            {
                if (operand.Equals(label[i]))
                {
                    int a = Convert.ToInt32(address[i], 16);
                    int b = Convert.ToInt32(address[index], 16);
                    s = Convert.ToString(a - b, 16);
                    if (s.Length == 4)
                    {
                        s = s.Substring(1);
                    }
                    else if (s.Length == 8)
                    {
                        s = s.Substring(5);
                    }
                    else
                    {
                        for (int j = s.Length; j < 3; j++)
                        {
                            s = "0" + s;
                        }
                    }
                    
                }
            }
            
            return s;
        }
        private string CreateAddressPart(string operand)
        {
            if (operand.StartsWith("@") || operand.StartsWith("#"))
            {
                operand = operand.Substring(1);
            }
            string str = "";
            for (int i = 0; i < label.Count; i++)
            {
                if (operand.Equals(label[i]))
                {
                    str = address[i];
                    break;
                }
            }
            for (int i = str.Length; i < 5; i++)
            {
                str = "0" + str;
            }
           
            return str;
        }

        private string RemoveXBit(string operand)
        {
            if (operand.Contains(",X"))
                return operand.Substring(0, operand.IndexOf(","));
            else
                return operand;
        }

        public string CreateObjectCode(string command, string operand, int index)
        {
            string ObCode = "";

            if (command.Equals("STL") || command.Equals("JSUB") || command.Equals("LDA") || command.Equals("COMP") || command.Equals("JEQ") || command.Equals("J") ||
                command.Equals("STA") || command.Equals("LDL") || command.Equals("LDX") || command.Equals("TD") || command.Equals("RD") || command.Equals("STCH") ||
                command.Equals("JLT") || command.Equals("STX") || command.Equals("LDCH") || command.Equals("RSUB") || command.Equals("TIX"))
            {
                ObCode = GetMachineCode(command);
                int dec = Convert.ToInt32(ObCode, 16);
                if (operand.StartsWith("#"))
                {
                    dec++;
                    ObCode = HelperToObjectCode(dec, operand);
                    if (char.IsDigit(operand[1]))
                    {
                        string str = operand.Substring(1);
                        int n = Convert.ToInt32(str);
                        str = Convert.ToString(n, 16);
                        for (int i = str.Length; i < 3; i++)
                        {
                            str = "0" + str;
                        }
                        ObCode += str;
                    }
                    else
                    {
                        ObCode += CreateDispose(RemoveXBit(operand.Substring(1)), index);
                    }
                }
                else if (operand.StartsWith("@"))
                {
                    dec += 2;
                    ObCode = HelperToObjectCode(dec, operand);
                    ObCode += CreateDispose(RemoveXBit(operand.Substring(1)), index);
                }
                else if (operand.StartsWith("="))
                {
                    dec += 3;
                    ObCode = HelperToObjectCode(dec, operand);
                    string s = "";
                    for (int i = 0; i < commands.Count; i++)
                    {
                        if (operand.Equals(commands[i]))
                        {
                            int a = Convert.ToInt32(address[i - 1], 16);
                            int b = Convert.ToInt32(address[index], 16);
                            s = Convert.ToString(a - b, 16);
                            if (s.Length == 4)
                            {
                                s = s.Substring(1);
                            }
                            else if (s.Length == 8)
                            {
                                s = s.Substring(5);
                            }
                            else
                            {
                                for (int j = s.Length; j < 3; j++)
                                {
                                    s = "0" + s;
                                }
                            }
                        }
                    }
                    ObCode += s;
                }
                else if (!operand.Equals(""))
                {
                    dec += 3;
                    ObCode = HelperToObjectCode(dec, operand);
                    ObCode += CreateDispose(RemoveXBit(operand), index);
                }
                else
                {
                    ObCode += "0000";
                }
                for (int i = ObCode.Length; i < 6; i++)
                {
                    ObCode = "0" + ObCode;
                }
            }
            else if (command.StartsWith("+"))
            {
                ObCode = GetMachineCode(command.Substring(1));
                int dec = Convert.ToInt32(ObCode, 16);
                if (operand.StartsWith("#"))
                {
                    dec++;
                    ObCode = HelperToObjectCode1(dec, operand);
                    if (char.IsDigit(operand[1]))
                    {
                        string str = operand.Substring(1);
                        int n = Convert.ToInt32(str);
                        str = Convert.ToString(n, 16);
                        for (int i = str.Length; i < 5; i++)
                        {
                            str = "0" + str;
                        }
                        ObCode += str;
                    }
                    else ObCode += CreateAddressPart(RemoveXBit(operand));
                }
                else if (operand.StartsWith("@"))
                {
                    dec += 2;
                    ObCode = HelperToObjectCode1(dec, operand);
                    ObCode += CreateAddressPart(RemoveXBit(operand));
                }
                else if (!operand.Equals(""))
                {
                    dec += 3;
                    ObCode = HelperToObjectCode1(dec, operand);
                    ObCode += CreateAddressPart(RemoveXBit(operand));
                }
                else
                {
                    ObCode += "000000";
                }
                for (int i = ObCode.Length; i < 8; i++)
                {
                    ObCode = "0" + ObCode;
                }
            }
            else if (command.StartsWith("=C"))
            {
                string s = "";
                int m = command.IndexOf("'") + 1;
                string str = command.Substring(m, command.LastIndexOf("'") - m);
                for (int i = 0; i < str.Length; i++)
                {
                    s += Convert.ToString(str[i], 16);
                }
                ObCode += s;
            }
            else if (command.StartsWith("=X"))
            {
                int m = command.IndexOf("'") + 1;
                string str = command.Substring(m, command.LastIndexOf("'") - m);
                ObCode += str;
            }
            else if (command.Equals("BYTE"))
            {
                string s = operand.Substring(2, operand.LastIndexOf("'") - 2);
                if (operand.StartsWith("C"))
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        ObCode += Convert.ToString(s[j], 16);
                    }
                }
                else
                {
                    ObCode += s;
                }

            }
            else if (command.Equals("WORD"))
            {
                ObCode = Convert.ToString(Convert.ToInt32(operand), 16);
                for (int i = ObCode.Length; i < 6; i++)
                {
                    ObCode = "0" + ObCode;
                }
            }
            ObCode = ObCode.ToUpper();
            return ObCode;
        }
    }
}
