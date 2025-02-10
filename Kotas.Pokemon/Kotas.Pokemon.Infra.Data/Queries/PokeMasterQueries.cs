namespace Kotas.Pokemon.Infra.Data.Queries;

public class PokeMasterQueries
{
    public const string Get =
        @"
            SELECT
                Id, 
                Name, 
                Age, 
                Document, 
                CreatedAt
            FROM PokeMaster
            WHERE Id = @Id;
        ";

    public const string Insert =
        @"
            INSERT INTO PokeMaster
                (Name, Age, Document, CreatedAt)
            VALUES 
                (@Name, @Age, @Document, @CreatedAt);

            SELECT last_insert_rowid();
        ";
}
