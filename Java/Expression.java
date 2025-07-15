import java.util.Arrays;
import java.lang.Integer;
import java.util.ArrayList;

public class Expression
{
    // variáveis de instância - substitua o exemplo abaixo pelo seu próprio
    public ArrayList<String> expressions;
    public ArrayList<String[]> groups;
    public int varCount;
    
    public Expression(int [] trueValues)
    {
        ArrayList<String> expressions = new ArrayList<String>();
        this.varCount = Integer.toBinaryString(trueValues[trueValues.length - 1]).length();
        for (int i = 0; i < trueValues.length; i++){
            expressions.add(Integer.toBinaryString(trueValues[i]));
            //this.expressions[i] = Integer.toBinaryString(trueValues[i]);
        }
        this.expressions = expressions;
        int index = 0;
        ArrayList<String[]> groups = new ArrayList<String[]>();
        String [] currentGroup;
        do{
            currentGroup = groupExpressions(index);
            if (currentGroup[0] != null){
                groups.add(currentGroup);
            }
            index++;
        }while (currentGroup[0] != null);
        this.groups = groups;
    }
    
    public String[] groupExpressions(int groupIndex){
        if (expressions == null){
            return null;
        }
        String [] buffer = new String[expressions.size()];
        int bufferIndex = 0;
        for(int i = 0; i < expressions.size(); i++){
            if ((expressions.get(i).replace("0", "").length() - 1) == groupIndex){
                buffer[bufferIndex] = expressions.get(i);
                bufferIndex++;
            }
        }
        String [] result = new String[bufferIndex + 1];
        for(int i = 0; i < bufferIndex; i++){
            result[i] = buffer[i];
        }
        return result;
    }
    }
