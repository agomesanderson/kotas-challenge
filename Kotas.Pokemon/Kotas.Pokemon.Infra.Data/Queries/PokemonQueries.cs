namespace Kotas.Pokemon.Infra.Data.Queries;

public class PokemonQueries
{
    public const string Get =
        @"
            SELECT
                Id,
                PokemonId, 
                PokeMasterId, 
                CreatedAt
            FROM Pokemon
            WHERE PokemonId = @Id;
        ";

    public const string GetAll =
        @"
            SELECT 
                Id,
                PokemonId,
                PokeMasterId,
                CreatedAt,
                UpdatedAt,
                (SELECT COUNT(*) FROM Pokemon) AS TotalItems,
                @QuantityByPage AS QuantityByPage
            FROM Pokemon
            ORDER BY CreatedAt DESC
            LIMIT @QuantityByPage OFFSET @ActualPage
        ";

    public const string Insert =
        @"
            INSERT INTO Pokemon
                (PokemonId, PokeMasterId, CreatedAt)
            VALUES 
                (@PokemonId, @PokeMasterId, @CreatedAt);

            SELECT last_insert_rowid();
        ";
}
