namespace Polymorphism
{
    public class Books(string name, string authorName) : Author(authorName)
    {
        // property new, replacing AuthorName
        public override string Name { get; protected set; } = name;

        // index new, replacing author bio pages, hides the pagesFieldFrom base class
        public new string[] pagesField = new string[100];

        public new string this[int i]
        {
            get => pagesField[i];
            set => pagesField[i] = value;
        }

        public override int CountPages()
        {
            return pagesField.Length;
        }

        public override string GetPageAt(int index)
        {
            return pagesField[index];
        }

#pragma warning disable CA1822 // Mark members as static
        public string GetPageAt(double index)
#pragma warning restore CA1822 // Mark members as static
        {
            return "Override was cancelled.";
        }

        public string GetAuthorName()
        {
            return base.Name;
        }

        public void SetAuthorBio(string page, int index)
        {
            base[index] = page;
        }

        public string GetAuthorPage(int index)
        {
            return base[index];
        }

        public int CountAuthorBioPages()
        {
            return base.CountPages();
        }
    }

    public class Author(string name)
    {
        public virtual string Name { get; protected set; } = name;

        public string[] pagesField = new string[1_000];

        public virtual string this[int i]
        {
            get => pagesField[i];
            set => pagesField[i] = value;
        }

        public virtual int CountPages()
        {
            return pagesField.Length;
        }

        public virtual string GetPageAt(int index)
        {
            return pagesField[index];
        }
    }
}
