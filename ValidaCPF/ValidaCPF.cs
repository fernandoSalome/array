using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidaCPF
{
    class ValidadorCPF
    {
        //criando um método estático com retorno
        // bool -> (verdadeiro ou falso) está relacionado ao dígito do cpf se é valido ou não
        //string numcpf -> está relacionado com a variável principal que captura o cpf a ser validado
        public static bool verificaCPF(string numcpf)
        {
            //algorítimo de validação do CPF
            //http://www.gerardocumentos.com.br/?pg=entenda-a-formula-do-cpf

            //variáveis de apoio a lógica de validação do cpf
            string cpf, digito;
            int soma, resto;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            //lógica principal
            // a linha abaixo separa os dígitos do cpf
            // numcpf é o número do cpf que foi capturado pelo form1
            cpf = numcpf.Substring(0, 9);
            soma = 0;
            /* --------------Primeiro digito verificador*/
            // o laço abaixo é usado para associar um número aos digitos do cpf, já multiplicando e somando o valor conforme algorítimo
            //+= (soma ao resultado a cada loop)
            //int.Parse (converte para inteiro)
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicador1[i];
            }
            // a estrura abaixo se refere ao 4 ítem do algorítimo de validação
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            /* --------------Segundo digito verificador*/
            digito = resto.ToString();
            cpf = cpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            
            //retorno do método de validação
            //a função EndsWith determina se o final de uma string corresponde a uma sequencia de caracteres especificada
            //true(1) -> corresponde
            //false(0) -> não corresponde
            return numcpf.EndsWith(digito);

        }
    }
}
