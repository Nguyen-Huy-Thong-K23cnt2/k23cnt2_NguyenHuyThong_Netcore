namespace day3.Models
{
    public class Book
    {
       public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenerId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        //danh sách các cuốn sách
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id =1,
                    Title = "Chí Phèo",
                    AuthorId =1,
                    GenerId = 1,
                    Image = "/img/chipheo.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book(){ },
            };

            return books;
        }
    }
}
