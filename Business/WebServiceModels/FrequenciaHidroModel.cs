using Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.WebServiceModels
{
    public class FrequenciaHidroModel
    {
        public virtual int AlunoId { get; set; }
        public DateTime Data { get; set; }
        public bool Selecionado { get; set; }

        public FrequenciaHidro ConvertToDTO()
        {
            var freq = new FrequenciaHidro();
            freq.AlunoId = this.AlunoId;
            freq.Data = this.Data;
            freq.Selecionado = this.Selecionado ? 1 : 0;
            
            return freq;
        }

        public static FrequenciaHidroModel ConvertToModel(FrequenciaHidro freq)
        {
            var freqModel = new FrequenciaHidroModel();
            freqModel.AlunoId = freq.AlunoId;
            freqModel.Data = freq.Data;
            freqModel.Selecionado = freq.Selecionado == 1;

            return freqModel;
        }

    }
}
