using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkey.Domain.Entites;

namespace BulkeyWebManage.Domain.Entites;

public class BookCatalogue:BaseEntity
{
    public int BookId{get;set;}
    [ForeignKey(nameof(BookId))]//ForeignKey("BookId")
    public Book? Book{get;set;}
    public int CatalogueId{get;set;}
    
    [ForeignKey(nameof(CatalogueId))]
    public  Catalogue? Catalogue{get;set;}  

}
