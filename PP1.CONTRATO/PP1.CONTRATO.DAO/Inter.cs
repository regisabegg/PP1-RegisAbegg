using System.Collections.Generic;

namespace PP1.CONTRATO.DAO
{
    public interface Inter<qualquerClasse>
    {
        void create(qualquerClasse obj);
        void delete(qualquerClasse obj);
        void update(qualquerClasse obj);
        bool find(qualquerClasse obj);
        List<qualquerClasse> findAll();
    }
}
