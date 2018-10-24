using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class FrequenciaHidroBase
    {
        private FrequenciaHidroDO frequenciaHidroDO = null;

        #region Properties

        internal FrequenciaHidroDO FrequenciaHidroDO
        {
            get { return frequenciaHidroDO; }
            set { this.frequenciaHidroDO = value; }
        }

        public virtual int AlunoId
        {
            get { return frequenciaHidroDO.AlunoId; }
            set { this.frequenciaHidroDO.AlunoId = value; }
        }

        public virtual DateTime Data
        {
            get { return frequenciaHidroDO.Data; }
            set { this.frequenciaHidroDO.Data = value; }
        }

        public virtual int Selecionado
        {
            get { return frequenciaHidroDO.Selecionado; }
            set { this.frequenciaHidroDO.Selecionado = value; }
        }


        #endregion

        #region Construtores

        public FrequenciaHidroBase()
        {
            frequenciaHidroDO = new FrequenciaHidroDO();
        }

        internal FrequenciaHidroBase(FrequenciaHidroDO frequenciaHidroDO)
        {
            this.frequenciaHidroDO = frequenciaHidroDO;
        }

        #endregion

    }
}


