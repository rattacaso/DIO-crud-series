using System.Collections.Generic;

namespace cadastro.interfaces
{
    public interface IRepositorio<S>
    {
        List<S> Lista();
        S RetornaPorId(int id);
        void Insere(S entidade);
        void Exclui(int id);
        void Atualiza(int id, S entidade);
        int ProximoId();
         
    }
    
}