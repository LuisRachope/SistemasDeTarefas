using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasDeTarefas.Models.Enums
{
    public enum StatusTarefa
    {
        [Description("A Fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluido = 3
    }
}
