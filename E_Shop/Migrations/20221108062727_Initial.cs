using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Shop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wallet = table.Column<double>(type: "float", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinaly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryToProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryToProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "محصولات ورزشی", "ورزشی" },
                    { 2, "محصولات مردانه", "مردانه" },
                    { 3, "لوازم جانبی موبایل", "لوازم جانبی" },
                    { 4, "", "کتاب" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, 5000m, 1 },
                    { 2, 15000m, 10 },
                    { 3, 45000m, 24 },
                    { 4, 137000m, 50 },
                    { 5, 153000m, 10 },
                    { 6, 100000m, 25 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsAdmin", "Password", "RegisterDate", "Wallet" },
                values: new object[] { 1, "admin@admin.com", true, "admin", new DateTime(2022, 11, 8, 9, 57, 27, 41, DateTimeKind.Local).AddTicks(6617), 1000000.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[,]
                {
                    { 1, "تیشرت ورزشی مردانه شرکت متفرقه", 1, "تیشرت ورزشی مردانه " },
                    { 2, "پیرهن مردانه رسمی ", 2, "پیراهن مردانه" },
                    { 3, "کلاس ورزشی مردانه", 3, "کلاه مردانه" },
                    { 4, " برای اکثر گوشی‌های موبایل طراحی شده و وزن کمی دارد. این پایه به سادگی و با استفاده از یک گیره روی دریچه هوای خودرو نصب می‎‌شود. این هولدر با استفاده از بازوهای کشویی گوشی موبایل را دربر می‌‎گیرد و به گونه‎ای طراحی شده که با قرار دادن گوشی موبایل در هولدر، بازوی زیرین هولدر هم کشیده می‎‌شود در نهایت به اندازه سایز گوشی کاربر تنظیم می‎‌شود. البته باید توجه داشت که بازوهای کناری این هلدر حداکثر به اندازه 88 میلی‎‌متر باز می‌‎شود. از ویژگی‌های این پایه نگهدارنده می‌توان به قابلیت چرخش 360 درجه آن اشاره کرد. این قابلیت شما را از امکان تماشای صفحه‌ نمایش گوشی موبایل در زوایای مختلف برخوردار می‌کند و در عکاسی سلفی هم بسیار کاربردی است. پایه نگهدارنده مدل  THL1207 تسکو برای استفاده در خودرو کاربرد زیادی دارد و اگر هنگام رانندگی از تماس‌های ویدیویی یا اپلیکیشن‌های مسیریابی استفاده می‌کنید بهتر است گوشی موبایل خود را در این پایه قرار دهید تا رانندگی ایمن‌تری داشته باشید.", 4, "پایه نگهدارنده گوشی موبایل تسکو" },
                    { 5, "نمودارهای شمعی ژاپنی قدمتی فراتر از نمودارهای میله‌ای و حتی نمودارهای نقطه و رقم دارند. کار با این نمودارها، هیجان‌انگیز، نیروبخش و مفرح است. استفاده از این تکنیک‌ها شما در تحلیل بهتر بازار و کسب سود بیشتر یاری می‌کند. ابزارها و تکنیک‌های معرفی شده در این کتاب در هربازاری کارایی و تاثیر خود را حفظ می‌کند. از تکنیک‌های نمودارهای شمعی می‌توان در نوسان‌گیری و سرمایه‌گذاری‌های کوتاه‌مدت بهره برد. این تکنیک‌ها می‌توانند در بازارهای فیوچر، سهام، اپشن و یا هرجای دیگری که تحلیل تکنیکال کاربرد دارد، موثر و مفید واقع شوند. در کتاب الگوهای شمعی ژاپنی نویسنده به تفسیر بیش از 50 الگو و شمع مختلف پرداخته و به ترکیب الگوهای شمعی با تکنیک های غربی نموده تا بتواند پایه مستحکمی از الگو های قیمتی ارائه نماید. روش تکنیکال، روشی است که قادر به تشخیص و اندازه گیری هیجانات آمیخته در بازار است. نام گذاری‌ها در نمودار‌های شمعی ژاپنی نیز به وضوح از این مطلب پیروی می کنند. این نام‌ها با ترفند‌های گوناگون در تلاشند تا وضعیت هیجانی حاکم بر بازار را در هنگام وقوع این الگو‌ها، بهتر تشریح کنند. بعد از شنیدن عبارت «دارآویز» یا «ابر سیاه» آیا امکان دارد که فکر کنید بازار از نظر هیجانی در موقعیت مناسبی قرار دارد؟ هر دوی این الگو‌ها، الگو‌هایی کاهشی هستند و نامشان به وضوح مشخص می کند که بازار در وضعیت نامتعادلی قرار دارد. البته اینکه وضعیت هیجانی بازار در زمان تشکیل این الگو‌ها نامساعد است، این احتمال را که بازار دوباره به آرامش برسد، رد نمی کند. نکته اینجاست که در هنگام تشکیل الگوی ابر سیاه، خرید‌ها باید در وضعیت تدافعی قرار گیرند، یا حداقل بر اساس جهت کلی روند یا سایر فاکتور‌ها تصمیم‌گیری شود و فروش‌های جدید می توانند آغاز شوند. ", 5, "کتاب الگوهای شمعی " },
                    { 6, "کتاب «خودت را به فنا نده» نوشته‌ی «گری جان بیشاپ» نویسنده‌ی اسکاتلندی‌ست که اولین بار در سال 2016 انتشار یافت. این کتاب که از پرفروش‌ترین کتاب‌های نیویورک تایمز است کمک می‌کند تا به بهترین خودتان تبدیل شوید. در پشت جلد آن آمده: تمام مدتی که درگیر بگومگو و قضاوت‌های درونی هستی، و البته هیچ‌وقت هم متوقف نخواهند شد، صدایی آرام زیر گوشت زمزمه می‌کند: «خیلی تنبل و خرفتی و اصلا به درد هیچ کاری نمی‌خوری» تو حتی متوجه نیستی چقدر به این زمزمه اعتقاد داری یا چه اندازه تباهت می‌کند. تو فقط تمام روز کار می‌کنی تا بر استرس‌ها و فشارهای روحی‌ات چیره شوی، زندگی‌ات را نجات دهی و اگر نتوانی چرخ لعنتی زندگی را بچرخانی، تن به تسلیم می‌دهی و شاید هرگز به جایی که می‌خواستی در زندگی نرسی. شاید هیچ‌گاه به آن شادی، اندام ایده‌آل، شغل یا ارتباطی که آرزویش را داری نرسی. این کتاب به کسانی اختصاص دارد که آن خودگویی‌های بی‌حاصل را تجربه کرده‌اند. جریان بی‌پایان شک و بهانه، زندگی روزمره را به گند می‌کشد. این کتاب، سیلی دنیاست که بیدارت کند تا توانایی‌هایت را کشف کنی، خودت را به فنا ندهی و به بهترین خودت در زندگی تبدیل شوی. کتاب خودت را به فنا نده اثر گری جان بیشاپ با ترجمه‌ی «حسین گازر» توسط انتشارات «کتاب کوله‌پشتی» منتشر شده است.", 6, "کتاب خودت را به فنا نده " }
                });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryToProducts_ProductId",
                table: "CategoryToProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemId",
                table: "Products",
                column: "ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryToProducts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
