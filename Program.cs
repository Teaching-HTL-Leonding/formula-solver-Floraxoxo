Console.Clear();

#region variables
int indexOfPlus = 0, indexOfMinus = 0;
bool containsPlus = true, containsMinus = true; //bool to check if check if the formula contains a minus or a plus
#endregion

#region code 
Console.Write("Please enter a formula: ");
string formula = Console.ReadLine()!.Replace(" ", "");
containsPlus = formula.Substring(1).Contains("+"); containsMinus = formula.Substring(1).Contains("-"); //ignore the first string and check where the nearest minus/plus is
if (formula.Length == 0 || (!containsMinus && !containsPlus)) { Console.WriteLine(GiveEasyResult(0)); } //Go into the method GiveEasyResult if there is no minus/plus or the length of the formula is 0
else { Console.WriteLine(GiveHardResult(0)); }
#endregion

#region methods
int GiveEasyResult(int result)
{
    if (formula.Length == 0) { return result; }
    else { result = int.Parse(formula); return result; }
}
int GiveHardResult(int result)
{
    do
    {
        if (formula[0] == '+' || formula[0] == '-') { indexOfPlus = formula.Substring(1).IndexOf("+") + 1; indexOfMinus = formula.Substring(1).IndexOf("-") + 1; }
        else { indexOfPlus = formula.IndexOf("+"); indexOfMinus = formula.IndexOf("-"); }
        if (indexOfPlus <= 0) { indexOfPlus = int.MaxValue; }
        if (indexOfMinus <= 0) { indexOfMinus = int.MaxValue; }
        if (indexOfMinus != indexOfPlus)
        {
            int minimum = int.Min(indexOfMinus, indexOfPlus);
            result += int.Parse(formula.Substring(0, minimum));
            formula = formula.Substring(minimum);
        }
        else {result += int.Parse(formula);}
    } while (indexOfMinus != indexOfPlus);
    return result;
}
#endregion