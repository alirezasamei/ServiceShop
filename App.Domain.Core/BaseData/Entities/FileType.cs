using App.Domain.Core.Expert.Entities;
using App.Domain.Core.Service.Entities;

namespace App.Domain.Core.BaseData.Entities
{
    public class FileType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public bool IsDeleted { get; set; }
    }
}
