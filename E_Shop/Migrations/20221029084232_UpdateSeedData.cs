using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "محصولات مردانه");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "لوازم جانبی موبایل", "لوازم جانبی" },
                    { 4, "", "کتاب" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 4, 137000m, 50 },
                    { 5, 153000m, 10 },
                    { 6, 100000m, 25 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 4, " برای اکثر گوشی‌های موبایل طراحی شده و وزن کمی دارد. این پایه به سادگی و با استفاده از یک گیره روی دریچه هوای خودرو نصب می‎‌شود. این هولدر با استفاده از بازوهای کشویی گوشی موبایل را دربر می‌‎گیرد و به گونه‎ای طراحی شده که با قرار دادن گوشی موبایل در هولدر، بازوی زیرین هولدر هم کشیده می‎‌شود در نهایت به اندازه سایز گوشی کاربر تنظیم می‎‌شود. البته باید توجه داشت که بازوهای کناری این هلدر حداکثر به اندازه 88 میلی‎‌متر باز می‌‎شود. از ویژگی‌های این پایه نگهدارنده می‌توان به قابلیت چرخش 360 درجه آن اشاره کرد. این قابلیت شما را از امکان تماشای صفحه‌ نمایش گوشی موبایل در زوایای مختلف برخوردار می‌کند و در عکاسی سلفی هم بسیار کاربردی است. پایه نگهدارنده مدل  THL1207 تسکو برای استفاده در خودرو کاربرد زیادی دارد و اگر هنگام رانندگی از تماس‌های ویدیویی یا اپلیکیشن‌های مسیریابی استفاده می‌کنید بهتر است گوشی موبایل خود را در این پایه قرار دهید تا رانندگی ایمن‌تری داشته باشید.", 4, "پایه نگهدارنده گوشی موبایل تسکو" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 5, "نمودارهای شمعی ژاپنی قدمتی فراتر از نمودارهای میله‌ای و حتی نمودارهای نقطه و رقم دارند. کار با این نمودارها، هیجان‌انگیز، نیروبخش و مفرح است. استفاده از این تکنیک‌ها شما در تحلیل بهتر بازار و کسب سود بیشتر یاری می‌کند. ابزارها و تکنیک‌های معرفی شده در این کتاب در هربازاری کارایی و تاثیر خود را حفظ می‌کند. از تکنیک‌های نمودارهای شمعی می‌توان در نوسان‌گیری و سرمایه‌گذاری‌های کوتاه‌مدت بهره برد. این تکنیک‌ها می‌توانند در بازارهای فیوچر، سهام، اپشن و یا هرجای دیگری که تحلیل تکنیکال کاربرد دارد، موثر و مفید واقع شوند. در کتاب الگوهای شمعی ژاپنی نویسنده به تفسیر بیش از 50 الگو و شمع مختلف پرداخته و به ترکیب الگوهای شمعی با تکنیک های غربی نموده تا بتواند پایه مستحکمی از الگو های قیمتی ارائه نماید. روش تکنیکال، روشی است که قادر به تشخیص و اندازه گیری هیجانات آمیخته در بازار است. نام گذاری‌ها در نمودار‌های شمعی ژاپنی نیز به وضوح از این مطلب پیروی می کنند. این نام‌ها با ترفند‌های گوناگون در تلاشند تا وضعیت هیجانی حاکم بر بازار را در هنگام وقوع این الگو‌ها، بهتر تشریح کنند. بعد از شنیدن عبارت «دارآویز» یا «ابر سیاه» آیا امکان دارد که فکر کنید بازار از نظر هیجانی در موقعیت مناسبی قرار دارد؟ هر دوی این الگو‌ها، الگو‌هایی کاهشی هستند و نامشان به وضوح مشخص می کند که بازار در وضعیت نامتعادلی قرار دارد. البته اینکه وضعیت هیجانی بازار در زمان تشکیل این الگو‌ها نامساعد است، این احتمال را که بازار دوباره به آرامش برسد، رد نمی کند. نکته اینجاست که در هنگام تشکیل الگوی ابر سیاه، خرید‌ها باید در وضعیت تدافعی قرار گیرند، یا حداقل بر اساس جهت کلی روند یا سایر فاکتور‌ها تصمیم‌گیری شود و فروش‌های جدید می توانند آغاز شوند. ", 5, "کتاب الگوهای شمعی ژاپنی اثر استیو نیسون نشر چالش" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 6, "کتاب «خودت را به فنا نده» نوشته‌ی «گری جان بیشاپ» نویسنده‌ی اسکاتلندی‌ست که اولین بار در سال 2016 انتشار یافت. این کتاب که از پرفروش‌ترین کتاب‌های نیویورک تایمز است کمک می‌کند تا به بهترین خودتان تبدیل شوید. در پشت جلد آن آمده: تمام مدتی که درگیر بگومگو و قضاوت‌های درونی هستی، و البته هیچ‌وقت هم متوقف نخواهند شد، صدایی آرام زیر گوشت زمزمه می‌کند: «خیلی تنبل و خرفتی و اصلا به درد هیچ کاری نمی‌خوری» تو حتی متوجه نیستی چقدر به این زمزمه اعتقاد داری یا چه اندازه تباهت می‌کند. تو فقط تمام روز کار می‌کنی تا بر استرس‌ها و فشارهای روحی‌ات چیره شوی، زندگی‌ات را نجات دهی و اگر نتوانی چرخ لعنتی زندگی را بچرخانی، تن به تسلیم می‌دهی و شاید هرگز به جایی که می‌خواستی در زندگی نرسی. شاید هیچ‌گاه به آن شادی، اندام ایده‌آل، شغل یا ارتباطی که آرزویش را داری نرسی. این کتاب به کسانی اختصاص دارد که آن خودگویی‌های بی‌حاصل را تجربه کرده‌اند. جریان بی‌پایان شک و بهانه، زندگی روزمره را به گند می‌کشد. این کتاب، سیلی دنیاست که بیدارت کند تا توانایی‌هایت را کشف کنی، خودت را به فنا ندهی و به بهترین خودت در زندگی تبدیل شوی. کتاب خودت را به فنا نده اثر گری جان بیشاپ با ترجمه‌ی «حسین گازر» توسط انتشارات «کتاب کوله‌پشتی» منتشر شده است.", 6, "کتاب خودت را به فنا نده اثر گری جان بیشاپ" });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "محصولات مزدانه");
        }
    }
}
