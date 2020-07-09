using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Entities;
using YY.Needle.Domain.Interfaces.Repository.ReadOnly;

namespace YY.Needle.Data.Repository.Dapper
{
    public class Lottery3DDapperRepository : Common.Repository, ILottery3DReadOnlyRepository
    {
        public Lottery3D Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var artist = cn.Query<Lottery3D>("SELECT * FROM Lottery3D WHERE id = @ArtistId",
                    new { ArtistiId = id }).FirstOrDefault();
                return artist;
            }
        }

        public IEnumerable<Lottery3D> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var artist = cn.Query<Lottery3D>("SELECT * FROM Lottery3D");
                return artist;
            }
        }

        public IEnumerable<Lottery3D> Find(Expression<Func<Lottery3D, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                // var artist = cn.GetList<Lottery3D>(predicate);
                return new List<Lottery3D>();
            }
        }
    }
}
