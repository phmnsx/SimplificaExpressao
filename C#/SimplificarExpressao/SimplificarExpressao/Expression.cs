using System;

public class Expression
{
	public List<string> Expressions { get; }
	public List<List<string>> Groups { get; }
    private int VarCount { get; }
	public Expression(List<int> TrueValues)
	{
		TrueValues.Sort();
		this.Expressions = new List<string>();
		this.VarCount = Convert.ToString(TrueValues[^1], 2).Length;
		for (int i = 0; i < TrueValues.Count; i++)
		{
			Expressions.Add(Convert.ToString(TrueValues[i], 2));
		}
		int Index = 0;
		List<string>? CurrentGroup = new();
        this.Groups = new();
		do
		{
			CurrentGroup = GroupExpressions(Index);
			if (CurrentGroup != null )
			{
				this.Groups.Add(CurrentGroup);
			}
			Index++;
		} while (CurrentGroup != null);	

	}
	private List<string>? GroupExpressions(int GroupIndex)
	{
		string Buffer;
		List<string> GroupedExpressions = new();
		for (int i = 0; i < Expressions.Count; i++)
		{
            Buffer = Expressions[i];
			if((Buffer.Replace("0", "").Length - 1) == GroupIndex)
			{
				GroupedExpressions.Add(Expressions[i]);
			}
		}
		if (GroupedExpressions.Count == 0)
		{
			return null;
		}
		return GroupedExpressions;
	}

}
