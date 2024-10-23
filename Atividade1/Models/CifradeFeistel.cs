using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;

namespace SegurançadeRedes.Models
{
    public class CifradeFeistel
    {
       private int[] Cifra(int[] right, int[] chave){
            int [] resultado = new int [4];
            for(int i = 0; i < 4; i++){
                if(right[i] == chave [i]){
                    resultado[i] = 0;
                }else{
                    resultado[i] = 1;
                }
            }
            return resultado;
            }
        
        public int[] Criptografar(int [] bloco, int[] chave1, int[] chave2){
            int [] left = new int [4];
            int [] right = new int [4];
            Array.Copy(bloco,0,left,0,4);
            Array.Copy(bloco,4,right,0,4);
            int [] cifraright  = Cifra(right,chave1);
            int [] cifraleft = Cifra(left,cifraright);
            left = right;
            right = cifraleft;

            cifraright = Cifra(right,chave2);
            cifraleft =Cifra(left,cifraright);

            int [] resultado = new int[bloco.Length];
            for(int i = 0; i< 4;i++){
                resultado [i] = right[i];
                resultado [i+4] = cifraleft[i];
            }
            
            return resultado;

        }

        public int[] Descriptografar(int [] bloco, int[] chave1, int[] chave2){
            int [] left = new int [4];
            int [] right = new int [4];
            Array.Copy(bloco,0,left,0,4);
            Array.Copy(bloco,4,right,0,4);
            int [] cifraleft  = Cifra(left,chave2);
            int [] cifraright = Cifra(right,cifraleft);
            right = left;
            left = cifraright;

            cifraleft  = Cifra(left,chave1);
            cifraright = Cifra(right,cifraleft);

            int [] resultado = new int[bloco.Length];
            for(int i = 0; i< 4;i++){
                resultado [i] = cifraright[i];
                resultado [i+4] = left[i];
            }
            
            return resultado;

        }
    }
}