namespace JulianaHote20171222.Models
{
 
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;


    public class Contexto : DbContext
    {
        #region Propriedades

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        #endregion

        #region Construtor


        public Contexto()
            : base("name=Contexto")
        {
        }


        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        #endregion

        #region M�todos

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configura o EF para n�o utilizar exclus�o em cascata.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Configura o EF para n�o criar index para todas as FK.
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();

            //Configura o EF para usar varchar como padr�o em vez de nvarchar.
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));

            //Configura um campo Decimal para ter um tamanho personalizado.
            modelBuilder.Entity<Colaborador>().Property(x => x.Salario).HasPrecision(14, 2);

        }



        #endregion
    }
}