using System.Text;

string alp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

//ввод буквенной части номера
string takestr()
{
    string lett;
    Console.Write("Введите буквенную часть: ");
    lett = Console.ReadLine().ToUpper();
    return lett;
}

//ввод численной части номера
string takenum()
{
    Console.Write("Введите численную часть: ");
    string number1 = Console.ReadLine();
    int number = int.Parse(number1);
    if (number >= 0 && number < 10000)
    {
        return number1;
    }
    return "0";
}

//подсчёт численной части след. номера
string calcnum(string num)
{
    int numb = int.Parse(num);
    int numb1 = numb + 1;
    if (numb != 9999 && numb >= 999)
    {
        return numb1.ToString();
    }
    if (numb < 999 && numb >= 99)
    {
        return "0" + numb1.ToString(); 
    }
    if (numb < 99 && numb >= 9)
    {
        return "00" + numb1.ToString();
    }
    if (numb < 9 && numb >= 0)
    {
        return "000" + numb1.ToString();
    }
    else{
        num = "0000";
        return num;
    }
    return numb1.ToString();
}

//подсчёт буквенной части след. номера
string calcstr(string lett, string numb)
{
    StringBuilder lett2 = new StringBuilder(lett);
    if (numb == "9999")
    {
        if (lett[2].ToString() == "Z")
        {
            if (lett[1].ToString() == "Z")
            {
                if (lett[0].ToString() == "Z")
                {
                    Console.WriteLine("Это поcледний номер");
                    return lett;
                }
                else
                {
                    lett2[2] = alp[0];
                    lett2[1] = alp[0];
                    lett2[0] = alp[alp.IndexOf(lett[0]) + 1];
                    return lett2.ToString();
                }
            }
            else
            {
                lett2[2] = alp[0];
                lett2[1] = alp[alp.IndexOf(lett[1]) + 1];
                return lett2.ToString();
            }
        }
        else
        {
            lett2[2] = alp[alp.IndexOf(lett[2]) + 1];
            return lett2.ToString();   
        }
    }
    return lett;
}

string mod(string lett, string number)
{
    string res = System.String.Concat(lett.OrderBy(c => c)) + " " + number;
    return res;
}

while (true)
{
    string takestr1 = takestr();
    string takenum1 = takenum();
    string calcnum1 = calcnum(takenum1);
    if(takenum1 == "0")
    {
        Console.WriteLine("число должно быть в диапазоне от 0 до 9999");
        break;
    }
    string result = mod(takestr1, takenum1);
    Console.WriteLine("Вы ввели: " + result);
    if (takestr1 != "ZZZ")
    {
        Console.WriteLine("Cледующий номер: " + calcstr(takestr1, takenum1) + " " + calcnum1);
    }
    else { calcstr(takestr1, takenum1); }
}