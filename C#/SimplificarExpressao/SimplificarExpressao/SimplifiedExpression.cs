using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimplificarExpressao
{
    
    public class SimplifiedExpression
    {
        public List<string> SimplifiedExpressions { get; set; }
        public List<string> AllExpressions { get; set; }
        public List<List<string>> Groups { get; set; }
        public SimplifiedExpression(Expression expression)
        {
            this.Groups = expression.Groups;
            this.AllExpressions = expression.Expressions;
            this.SimplifiedExpressions = new List<string>();
            int Changes;
            do
            {
                Changes = 0;
                for (int i = 0; i < this.Groups.Count; i++) // -1 ou -2 ?
                {
                    for (int j = i + 1; j < this.Groups.Count; j++)
                    {
                        if (!(this.Groups.Count < j))
                        {
                            this.SimplifiedExpressions.AddRange(CompareGroups(this.Groups[i], this.Groups[j]));
                        }
                    }
                }
                SimplifiedExpressions = [.. SimplifiedExpressions.Distinct()];
                AllExpressions.AddRange(SimplifiedExpressions);
                AllExpressions = [.. AllExpressions.Distinct()];
                bool b = EliminateEquivalents();
                if (b)
                {
                    Changes++;
                }
                List<string>? CurrentGroup = new();
                this.Groups = new();
                for (int i = 0; i < expression.VarCount; i++)
                {
                    CurrentGroup = GroupExpressions(i);
                    if (CurrentGroup == null)
                        break;
                    this.Groups.Add(CurrentGroup);
                }
                
            } while (Changes != 0);
        }


        private List<string> CompareGroups(List<string> GroupA, List<string> GroupB)
        {
            List<string> Result = [];
            string? StringResult = null;
            for (int i = 0; i < GroupA.Count; i++)
            {
                for(int j = 0; j < GroupB.Count; j++)
                {
                    StringResult = CompareStrings(GroupA[i], GroupB[j]);
                    if (StringResult != null)
                    {
                       Result.Add(StringResult);
                    }
                }
            }
            return Result;
        }

        private string? CompareStrings(string A, string B)
        {
            int ChangeIndex = 0;
            int ChangeCount = 0;
            for (int i = 0; i < A.Length;i++)
            {
                if (A[i] != B[i])
                {
                    ChangeIndex = i;
                    ChangeCount++;
                    
                }
            }
            if (ChangeCount != 1)
            {
                return null;
            }
            return A.Remove(ChangeIndex, 1).Insert(ChangeIndex, "-");
        }
        private List<string>? GroupExpressions(int GroupIndex)
        {
            string Buffer;
            List<string> GroupedExpressions = new();
            for (int i = 0; i < AllExpressions.Count; i++)
            {
                Buffer = AllExpressions[i];
                if ((Buffer.Replace("0", "").Replace("-", "").Length - 1) == GroupIndex)
                {
                    GroupedExpressions.Add(AllExpressions[i]);
                }
            }
            if (GroupedExpressions.Count == 0)
            {
                return null;
            }
            return GroupedExpressions;
        } //herança nao quis funcionar cmg
        private bool EliminateEquivalents()
        {
            int Changes = 0;
            string Dummy2;
            for(int i = 0; i < this.AllExpressions.Count; i++)
            {
                string Dummy = this.AllExpressions[i];
                for (int j = 0; j < this.AllExpressions.Count; j++)
                {
                  
                    if (CompareSimpleString(Dummy, this.AllExpressions[j]) && i != j)
                    {
                        Dummy2 = this.AllExpressions[j];
                        do
                        {

                        }while(this.AllExpressions.Remove(Dummy2));
                        Changes++;
                    }
                }
            }
            if (Changes == 0) { return false; }
            else { return true; }
        }

        private bool CompareSimpleString(string str1, string str2)
        {
            int Changes = 0;
            if (str1 == str2) { return false; }
            for (int i = 0; i < str1.Length; i++)
            {
                if ((str1[i] == str2[i]) || str1[i] == '-')
                {
                    Changes++;
                    
                } 
            }
            if (Changes != str1.Length) { return false; }
            else { return true; }
        }
        // 01-0
        // 01--
    }
    
}

