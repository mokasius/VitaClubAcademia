﻿using Business.Classes;
using System.Collections.Generic;

namespace Business.WebServiceModels
{
    public class DivisaoTreinoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int? TreinoId { get; set; }

        public int? Sequencia { get; set; }

        public string Descricao { get; set; }

        public List<ExercicioTreinoModel> Exercicios { get; set; }

        public DivisaoTreino ConvertToDTO()
        {
            var divisao = new DivisaoTreino();
            divisao.Id = this.Id;
            divisao.Nome = this.Nome;
            divisao.TreinoId = this.TreinoId;
            divisao.Sequencia = this.Sequencia;
            divisao.Descricao = this.Descricao;
            divisao.Exercicios.Clear();

            foreach (var exercicioModel in Exercicios)
            {
                var exercicio = exercicioModel.ConvertToDTO();
                divisao.Exercicios.Add(exercicio);
            }

            return divisao;
        }

        public static DivisaoTreinoModel ConvertToModel(DivisaoTreino divisaoTreino)
        {
            var divisaoModel = new DivisaoTreinoModel();
            divisaoModel.Id = divisaoTreino.Id;
            divisaoModel.Nome = divisaoTreino.Nome;
            divisaoModel.TreinoId = divisaoTreino.TreinoId;
            divisaoModel.Sequencia = divisaoTreino.Sequencia;
            divisaoModel.Descricao = divisaoTreino.Descricao;

            divisaoModel.Exercicios = new List<ExercicioTreinoModel>();
            foreach (var exercicioTreino in divisaoTreino.Exercicios)
            {
                var exercicioTreinoModel = ExercicioTreinoModel.ConvertToModel(exercicioTreino);
                divisaoModel.Exercicios.Add(exercicioTreinoModel);
            }

            return divisaoModel;
        }

    }
}