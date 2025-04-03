using Dapper;
using Dapper.Transaction;
using Microsoft.Extensions.Options;
using TestFinBeat.Dapper.Config;
using TestFinBeat.Dapper.Entities;
using TestFinBeat.Dapper.Queries;
using TestFinBeat.Services.Code;

namespace TestFinBeat.Dapper.Storage
{
    public class CodeStorage : TestStorage, ICodeStorage
    {
        public CodeStorage(IOptions<TestConfiguration> cfg) : base(cfg) { }

        public async Task<bool> InsertCodesAsync(List<CodeEntity> codes, CancellationToken cancellationToken = default)
        {
            await OpenConnectionAsync();
            using var transaction = await connection.BeginTransactionAsync(cancellationToken);

            try
            {
                await transaction.ExecuteAsync(CodeQueries.DeleteAllCodes());

                foreach (var code in codes)
                {
                    await transaction.ExecuteAsync(CodeQueries.InsertCode(), code);
                }

                await transaction.CommitAsync(cancellationToken);
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<CodeEntity>> SelectCodesAsync(int? id, int? code, string? value, CancellationToken cancellationToken = default)
        {
            await OpenConnectionAsync();
            var codes = await connection.QueryAsync<CodeEntity>(CodeQueries.SelectCodes(), new { Id = id, Code = code, Value = value });
            return codes.ToList();
        }
    }
}
