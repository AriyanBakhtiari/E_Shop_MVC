using E_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Data
{
    public class EShopContext : DbContext
    {
        //
        public EShopContext(DbContextOptions<EShopContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Select Key CategoryToProduct
            modelBuilder.Entity<CategoryToProduct>().HasKey(c => new { c.CategoryId, c.ProductId });
            #endregion

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
            });



            #region SeedData 
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "ورزشی",
                Description = "محصولات ورزشی"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "مردانه",
                Description = "محصولات مردانه"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "لوازم جانبی",
                Description = "لوازم جانبی موبایل"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Name = "کتاب",
                Description = ""
            });


            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Price = 5000,
                QuantityInStock = 1,
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Price = 15000,
                QuantityInStock = 10,
            }); 
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                Price = 45000,
                QuantityInStock = 24,
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 4,
                Price = 137000,
                QuantityInStock = 50,
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 5,
                Price = 153000,
                QuantityInStock = 10,
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 6,
                Price = 100000,
                QuantityInStock = 25,
            });



            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                ItemId = 1,
                Name = "تیشرت ورزشی مردانه ",
                Description = "تیشرت ورزشی مردانه شرکت متفرقه",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                ItemId = 2,
                Name = "پیراهن مردانه",
                Description = "پیرهن مردانه رسمی ",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                ItemId = 3,
                Name = "کلاه مردانه",
                Description = "کلاس ورزشی مردانه",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                ItemId = 4,
                Name = "پایه نگهدارنده گوشی موبایل تسکو",
                Description = " برای اکثر گوشی‌های موبایل طراحی شده و وزن کمی دارد. این پایه به سادگی و با استفاده از یک گیره روی دریچه هوای خودرو نصب می‎‌شود. این هولدر با استفاده از بازوهای کشویی گوشی موبایل را دربر می‌‎گیرد و به گونه‎ای طراحی شده که با قرار دادن گوشی موبایل در هولدر، بازوی زیرین هولدر هم کشیده می‎‌شود در نهایت به اندازه سایز گوشی کاربر تنظیم می‎‌شود. البته باید توجه داشت که بازوهای کناری این هلدر حداکثر به اندازه 88 میلی‎‌متر باز می‌‎شود. از ویژگی‌های این پایه نگهدارنده می‌توان به قابلیت چرخش 360 درجه آن اشاره کرد. این قابلیت شما را از امکان تماشای صفحه‌ نمایش گوشی موبایل در زوایای مختلف برخوردار می‌کند و در عکاسی سلفی هم بسیار کاربردی است. پایه نگهدارنده مدل  THL1207 تسکو برای استفاده در خودرو کاربرد زیادی دارد و اگر هنگام رانندگی از تماس‌های ویدیویی یا اپلیکیشن‌های مسیریابی استفاده می‌کنید بهتر است گوشی موبایل خود را در این پایه قرار دهید تا رانندگی ایمن‌تری داشته باشید.",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                ItemId = 5,
                Name = "کتاب الگوهای شمعی ",
                Description = "نمودارهای شمعی ژاپنی قدمتی فراتر از نمودارهای میله‌ای و حتی نمودارهای نقطه و رقم دارند. کار با این نمودارها، هیجان‌انگیز، نیروبخش و مفرح است. استفاده از این تکنیک‌ها شما در تحلیل بهتر بازار و کسب سود بیشتر یاری می‌کند. ابزارها و تکنیک‌های معرفی شده در این کتاب در هربازاری کارایی و تاثیر خود را حفظ می‌کند. از تکنیک‌های نمودارهای شمعی می‌توان در نوسان‌گیری و سرمایه‌گذاری‌های کوتاه‌مدت بهره برد. این تکنیک‌ها می‌توانند در بازارهای فیوچر، سهام، اپشن و یا هرجای دیگری که تحلیل تکنیکال کاربرد دارد، موثر و مفید واقع شوند. در کتاب الگوهای شمعی ژاپنی نویسنده به تفسیر بیش از 50 الگو و شمع مختلف پرداخته و به ترکیب الگوهای شمعی با تکنیک های غربی نموده تا بتواند پایه مستحکمی از الگو های قیمتی ارائه نماید. روش تکنیکال، روشی است که قادر به تشخیص و اندازه گیری هیجانات آمیخته در بازار است. نام گذاری‌ها در نمودار‌های شمعی ژاپنی نیز به وضوح از این مطلب پیروی می کنند. این نام‌ها با ترفند‌های گوناگون در تلاشند تا وضعیت هیجانی حاکم بر بازار را در هنگام وقوع این الگو‌ها، بهتر تشریح کنند. بعد از شنیدن عبارت «دارآویز» یا «ابر سیاه» آیا امکان دارد که فکر کنید بازار از نظر هیجانی در موقعیت مناسبی قرار دارد؟ هر دوی این الگو‌ها، الگو‌هایی کاهشی هستند و نامشان به وضوح مشخص می کند که بازار در وضعیت نامتعادلی قرار دارد. البته اینکه وضعیت هیجانی بازار در زمان تشکیل این الگو‌ها نامساعد است، این احتمال را که بازار دوباره به آرامش برسد، رد نمی کند. نکته اینجاست که در هنگام تشکیل الگوی ابر سیاه، خرید‌ها باید در وضعیت تدافعی قرار گیرند، یا حداقل بر اساس جهت کلی روند یا سایر فاکتور‌ها تصمیم‌گیری شود و فروش‌های جدید می توانند آغاز شوند. ",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                ItemId = 6,
                Name = "کتاب خودت را به فنا نده ",
                Description = "کتاب «خودت را به فنا نده» نوشته‌ی «گری جان بیشاپ» نویسنده‌ی اسکاتلندی‌ست که اولین بار در سال 2016 انتشار یافت. این کتاب که از پرفروش‌ترین کتاب‌های نیویورک تایمز است کمک می‌کند تا به بهترین خودتان تبدیل شوید. در پشت جلد آن آمده: تمام مدتی که درگیر بگومگو و قضاوت‌های درونی هستی، و البته هیچ‌وقت هم متوقف نخواهند شد، صدایی آرام زیر گوشت زمزمه می‌کند: «خیلی تنبل و خرفتی و اصلا به درد هیچ کاری نمی‌خوری» تو حتی متوجه نیستی چقدر به این زمزمه اعتقاد داری یا چه اندازه تباهت می‌کند. تو فقط تمام روز کار می‌کنی تا بر استرس‌ها و فشارهای روحی‌ات چیره شوی، زندگی‌ات را نجات دهی و اگر نتوانی چرخ لعنتی زندگی را بچرخانی، تن به تسلیم می‌دهی و شاید هرگز به جایی که می‌خواستی در زندگی نرسی. شاید هیچ‌گاه به آن شادی، اندام ایده‌آل، شغل یا ارتباطی که آرزویش را داری نرسی. این کتاب به کسانی اختصاص دارد که آن خودگویی‌های بی‌حاصل را تجربه کرده‌اند. جریان بی‌پایان شک و بهانه، زندگی روزمره را به گند می‌کشد. این کتاب، سیلی دنیاست که بیدارت کند تا توانایی‌هایت را کشف کنی، خودت را به فنا ندهی و به بهترین خودت در زندگی تبدیل شوی. کتاب خودت را به فنا نده اثر گری جان بیشاپ با ترجمه‌ی «حسین گازر» توسط انتشارات «کتاب کوله‌پشتی» منتشر شده است.",
            });


            modelBuilder.Entity<CategoryToProduct>().HasData(
            new CategoryToProduct { ProductId = 1, CategoryId = 1, },
            new CategoryToProduct { ProductId = 1, CategoryId = 2, },
            new CategoryToProduct { ProductId = 2, CategoryId = 1, },
            new CategoryToProduct { ProductId = 2, CategoryId = 2, },
            new CategoryToProduct { ProductId = 3, CategoryId = 1, },
            new CategoryToProduct { ProductId = 5, CategoryId = 4, },
            new CategoryToProduct { ProductId = 6, CategoryId = 4, },
            new CategoryToProduct { ProductId = 4, CategoryId = 3, },
            new CategoryToProduct { ProductId = 3, CategoryId = 2, });


            modelBuilder.Entity<Users>().HasData(new Users
            {
                UserId = 1,
                Email = "admin@admin.com",
                IsAdmin = true,
                Password = "admin",
                RegisterDate = System.DateTime.Now,
                Wallet = 10000000 , 
            }) ;
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
