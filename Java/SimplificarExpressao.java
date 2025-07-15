import java.util.Arrays;
import java.lang.Integer;
import java.util.ArrayList;
/**
 * Escreva uma descrição da classe SimplificarExpressao aqui.
 * 
 * @author (seu nome) 
 * @version (um número da versão ou uma data)
 */
public class SimplificarExpressao
{
    public static void main(String [] args){
        int [] array = {2, 4, 5, 8};
        Expression expressao = new Expression(array);
        System.out.println(expressao.expressions);
        System.out.println(expressao.groups);
    }
}
