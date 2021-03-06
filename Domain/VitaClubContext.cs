﻿using Domain.Classes;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

public class VitaClubContext : DbContext
{
    public VitaClubContext()
            : base("name=VitaClubContext")
    {
        Configuration.LazyLoadingEnabled = false;
    }
    public DbSet<AlunoDO> Alunos { get; set; }
    public DbSet<TreinoDO> Treinos { get; set; }
    public DbSet<DivisaoTreinoDO> DivisoesTreino { get; set; }
    public DbSet<ExercicioDO> Exercicios { get; set; }
    public DbSet<FrequenciaDO> Frequencias { get; set; }
    public DbSet<FrequenciaHidroDO> FrequenciasHidro { get; set; }
    public DbSet<ExercicioTreinoDO> ExerciciosTreino { get; set; }
    public DbSet<AlunoTreinoDO> AlunosTreinos { get; set; }
    public DbSet<PagamentoDO> Pagamentos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        MontaClasseAluno(modelBuilder);
        MontaClasseTreino(modelBuilder);
        MontaClasseDivisaoTreino(modelBuilder);
        MontaClasseExercicio(modelBuilder);
        MontaClasseFrequencia(modelBuilder);
        MontaClasseExercicioTreino(modelBuilder);
        MontaClasseAlunosTreinos(modelBuilder);
        MontaClassePagamento(modelBuilder);
        MontaClasseFrequenciaHidro(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    /*
    private void MontaClasseAlunosTreinos(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlunoDO>()
                .HasMany<TreinoDO>(s => s.Treinos)
                .WithMany(c => c.Alunos)
                .Map(cs =>
                {
                    cs.MapLeftKey("AlunoId");
                    cs.MapRightKey("TreinoId");
                    cs.ToTable("AlunosTreinos");
                });
    }
    */
    
    private void MontaClasseAluno(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlunoDO>().ToTable("Aluno");
        modelBuilder.Entity<AlunoDO>().HasKey(c => c.Id);
        modelBuilder.Entity<AlunoDO>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }

    private void MontaClasseAlunosTreinos(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlunoTreinoDO>().ToTable("AlunosTreinos");
        modelBuilder.Entity<AlunoTreinoDO>().HasKey(c => c.Id);
        modelBuilder.Entity<AlunoTreinoDO>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }


    private void MontaClasseTreino(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TreinoDO>().ToTable("Treino");
        modelBuilder.Entity<TreinoDO>().HasKey(c => c.Id);
        modelBuilder.Entity<TreinoDO>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //A chave estrangeira para a tabela Aluno
        //modelBuilder.Entity<TreinoDO>().HasRequired(c => c.Aluno)
        //     .WithMany(p => p.Treinos).HasForeignKey(p => p.AlunoId);

        // A deleção em cascata a partir de Aluno para Treinos
        //modelBuilder.Entity<TreinoDO>()
        //    .HasOptional(c => c.Aluno)
        //    .WithMany()
        //    .HasForeignKey(p => p.AlunoId)
        //    .WillCascadeOnDelete(false);
    }

    private void MontaClasseDivisaoTreino(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DivisaoTreinoDO>().ToTable("DivisaoTreino");
        modelBuilder.Entity<DivisaoTreinoDO>().HasKey(c => c.Id);

        //modelBuilder.Entity<DivisaoTreinoDO>().HasRequired(c => c.Treino)
        //     .WithMany(p => p.DivisoesTreino).HasForeignKey(p => p.TreinoId);

        //modelBuilder.Entity<DivisaoTreinoDO>()
        //    .HasOptional(c => c.Treino)
        //    .WithMany()
        //    .HasForeignKey(a => a.TreinoId)
        //    .WillCascadeOnDelete(false);
    }

    private void MontaClasseExercicio(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExercicioDO>().ToTable("Exercicio");
        modelBuilder.Entity<ExercicioDO>().HasKey(c => c.Id);
        modelBuilder.Entity<ExercicioDO>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //modelBuilder.Entity<ExercicioDO>().HasRequired(c => c.DivisaoTreino)
        //     .WithMany(p => p.Exercicios).HasForeignKey(p => p.DivisaoTreinoId);
    }

    private void MontaClasseExercicioTreino(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExercicioTreinoDO>().ToTable("ExercicioTreino");
        modelBuilder.Entity<ExercicioTreinoDO>().HasKey(c => new { c.DivisaoId, c.DivisaoSeq, c.Sequencia });
        //modelBuilder.Entity<ExercicioTreinoDO>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //modelBuilder.Entity<ExercicioDO>().HasRequired(c => c.DivisaoTreino)
        //     .WithMany(p => p.Exercicios).HasForeignKey(p => p.DivisaoTreinoId);
    }

    private void MontaClasseFrequencia(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FrequenciaDO>().ToTable("Frequencia");
        modelBuilder.Entity<FrequenciaDO>().HasKey(c => new { c.AlunoId, c.Sequencia });
    }

    private void MontaClasseFrequenciaHidro(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FrequenciaHidroDO>().ToTable("FrequenciaHidro");
        modelBuilder.Entity<FrequenciaHidroDO>().HasKey(c => new { c.AlunoId, c.Data });
    }

    private void MontaClassePagamento(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PagamentoDO>().ToTable("Pagamento");
        modelBuilder.Entity<PagamentoDO>().HasKey(c => new { c.Id, c.AlunoId, c.Mes, c.Ano });
        modelBuilder.Entity<ExercicioDO>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
    


}
