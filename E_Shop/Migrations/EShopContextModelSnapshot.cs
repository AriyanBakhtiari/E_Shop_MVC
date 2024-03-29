﻿// <auto-generated />
using System;
using E_Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Shop.Migrations
{
    [DbContext(typeof(EShopContext))]
    partial class EShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("E_Shop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "محصولات ورزشی",
                            Name = "ورزشی"
                        },
                        new
                        {
                            Id = 2,
                            Description = "محصولات مردانه",
                            Name = "مردانه"
                        },
                        new
                        {
                            Id = 3,
                            Description = "لوازم جانبی موبایل",
                            Name = "لوازم جانبی"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "کتاب"
                        });
                });

            modelBuilder.Entity("E_Shop.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CategoryToProducts");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 6
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("E_Shop.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 5000m,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = 2,
                            Price = 15000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 3,
                            Price = 45000m,
                            QuantityInStock = 24
                        },
                        new
                        {
                            Id = 4,
                            Price = 137000m,
                            QuantityInStock = 50
                        },
                        new
                        {
                            Id = 5,
                            Price = 153000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 6,
                            Price = 100000m,
                            QuantityInStock = 25
                        });
                });

            modelBuilder.Entity("E_Shop.Models.OrderDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("E_Shop.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_Shop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "تیشرت ورزشی مردانه شرکت متفرقه",
                            ItemId = 1,
                            Name = "تیشرت ورزشی مردانه "
                        },
                        new
                        {
                            Id = 2,
                            Description = "پیرهن مردانه رسمی ",
                            ItemId = 2,
                            Name = "پیراهن مردانه"
                        },
                        new
                        {
                            Id = 3,
                            Description = "کلاس ورزشی مردانه",
                            ItemId = 3,
                            Name = "کلاه مردانه"
                        },
                        new
                        {
                            Id = 4,
                            Description = " برای اکثر گوشی‌های موبایل طراحی شده و وزن کمی دارد. این پایه به سادگی و با استفاده از یک گیره روی دریچه هوای خودرو نصب می‎‌شود. این هولدر با استفاده از بازوهای کشویی گوشی موبایل را دربر می‌‎گیرد و به گونه‎ای طراحی شده که با قرار دادن گوشی موبایل در هولدر، بازوی زیرین هولدر هم کشیده می‎‌شود در نهایت به اندازه سایز گوشی کاربر تنظیم می‎‌شود. البته باید توجه داشت که بازوهای کناری این هلدر حداکثر به اندازه 88 میلی‎‌متر باز می‌‎شود. از ویژگی‌های این پایه نگهدارنده می‌توان به قابلیت چرخش 360 درجه آن اشاره کرد. این قابلیت شما را از امکان تماشای صفحه‌ نمایش گوشی موبایل در زوایای مختلف برخوردار می‌کند و در عکاسی سلفی هم بسیار کاربردی است. پایه نگهدارنده مدل  THL1207 تسکو برای استفاده در خودرو کاربرد زیادی دارد و اگر هنگام رانندگی از تماس‌های ویدیویی یا اپلیکیشن‌های مسیریابی استفاده می‌کنید بهتر است گوشی موبایل خود را در این پایه قرار دهید تا رانندگی ایمن‌تری داشته باشید.",
                            ItemId = 4,
                            Name = "پایه نگهدارنده گوشی موبایل تسکو"
                        },
                        new
                        {
                            Id = 5,
                            Description = "نمودارهای شمعی ژاپنی قدمتی فراتر از نمودارهای میله‌ای و حتی نمودارهای نقطه و رقم دارند. کار با این نمودارها، هیجان‌انگیز، نیروبخش و مفرح است. استفاده از این تکنیک‌ها شما در تحلیل بهتر بازار و کسب سود بیشتر یاری می‌کند. ابزارها و تکنیک‌های معرفی شده در این کتاب در هربازاری کارایی و تاثیر خود را حفظ می‌کند. از تکنیک‌های نمودارهای شمعی می‌توان در نوسان‌گیری و سرمایه‌گذاری‌های کوتاه‌مدت بهره برد. این تکنیک‌ها می‌توانند در بازارهای فیوچر، سهام، اپشن و یا هرجای دیگری که تحلیل تکنیکال کاربرد دارد، موثر و مفید واقع شوند. در کتاب الگوهای شمعی ژاپنی نویسنده به تفسیر بیش از 50 الگو و شمع مختلف پرداخته و به ترکیب الگوهای شمعی با تکنیک های غربی نموده تا بتواند پایه مستحکمی از الگو های قیمتی ارائه نماید. روش تکنیکال، روشی است که قادر به تشخیص و اندازه گیری هیجانات آمیخته در بازار است. نام گذاری‌ها در نمودار‌های شمعی ژاپنی نیز به وضوح از این مطلب پیروی می کنند. این نام‌ها با ترفند‌های گوناگون در تلاشند تا وضعیت هیجانی حاکم بر بازار را در هنگام وقوع این الگو‌ها، بهتر تشریح کنند. بعد از شنیدن عبارت «دارآویز» یا «ابر سیاه» آیا امکان دارد که فکر کنید بازار از نظر هیجانی در موقعیت مناسبی قرار دارد؟ هر دوی این الگو‌ها، الگو‌هایی کاهشی هستند و نامشان به وضوح مشخص می کند که بازار در وضعیت نامتعادلی قرار دارد. البته اینکه وضعیت هیجانی بازار در زمان تشکیل این الگو‌ها نامساعد است، این احتمال را که بازار دوباره به آرامش برسد، رد نمی کند. نکته اینجاست که در هنگام تشکیل الگوی ابر سیاه، خرید‌ها باید در وضعیت تدافعی قرار گیرند، یا حداقل بر اساس جهت کلی روند یا سایر فاکتور‌ها تصمیم‌گیری شود و فروش‌های جدید می توانند آغاز شوند. ",
                            ItemId = 5,
                            Name = "کتاب الگوهای شمعی "
                        },
                        new
                        {
                            Id = 6,
                            Description = "کتاب «خودت را به فنا نده» نوشته‌ی «گری جان بیشاپ» نویسنده‌ی اسکاتلندی‌ست که اولین بار در سال 2016 انتشار یافت. این کتاب که از پرفروش‌ترین کتاب‌های نیویورک تایمز است کمک می‌کند تا به بهترین خودتان تبدیل شوید. در پشت جلد آن آمده: تمام مدتی که درگیر بگومگو و قضاوت‌های درونی هستی، و البته هیچ‌وقت هم متوقف نخواهند شد، صدایی آرام زیر گوشت زمزمه می‌کند: «خیلی تنبل و خرفتی و اصلا به درد هیچ کاری نمی‌خوری» تو حتی متوجه نیستی چقدر به این زمزمه اعتقاد داری یا چه اندازه تباهت می‌کند. تو فقط تمام روز کار می‌کنی تا بر استرس‌ها و فشارهای روحی‌ات چیره شوی، زندگی‌ات را نجات دهی و اگر نتوانی چرخ لعنتی زندگی را بچرخانی، تن به تسلیم می‌دهی و شاید هرگز به جایی که می‌خواستی در زندگی نرسی. شاید هیچ‌گاه به آن شادی، اندام ایده‌آل، شغل یا ارتباطی که آرزویش را داری نرسی. این کتاب به کسانی اختصاص دارد که آن خودگویی‌های بی‌حاصل را تجربه کرده‌اند. جریان بی‌پایان شک و بهانه، زندگی روزمره را به گند می‌کشد. این کتاب، سیلی دنیاست که بیدارت کند تا توانایی‌هایت را کشف کنی، خودت را به فنا ندهی و به بهترین خودت در زندگی تبدیل شوی. کتاب خودت را به فنا نده اثر گری جان بیشاپ با ترجمه‌ی «حسین گازر» توسط انتشارات «کتاب کوله‌پشتی» منتشر شده است.",
                            ItemId = 6,
                            Name = "کتاب خودت را به فنا نده "
                        });
                });

            modelBuilder.Entity("E_Shop.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Wallet")
                        .HasColumnType("float");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@admin.com",
                            IsAdmin = true,
                            Password = "admin",
                            RegisterDate = new DateTime(2022, 11, 25, 13, 21, 37, 213, DateTimeKind.Local).AddTicks(1000),
                            Wallet = 1000000.0
                        });
                });

            modelBuilder.Entity("E_Shop.Models.CategoryToProduct", b =>
                {
                    b.HasOne("E_Shop.Models.Category", "Category")
                        .WithMany("CategoryToProduct")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Shop.Models.Product", "Product")
                        .WithMany("CategoryToProduct")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Shop.Models.OrderDetail", b =>
                {
                    b.HasOne("E_Shop.Models.Orders", "Orders")
                        .WithMany("OrderDatail")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Shop.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Shop.Models.Orders", b =>
                {
                    b.HasOne("E_Shop.Models.Users", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_Shop.Models.Product", b =>
                {
                    b.HasOne("E_Shop.Models.Item", "Item")
                        .WithOne("Product")
                        .HasForeignKey("E_Shop.Models.Product", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("E_Shop.Models.Category", b =>
                {
                    b.Navigation("CategoryToProduct");
                });

            modelBuilder.Entity("E_Shop.Models.Item", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Shop.Models.Orders", b =>
                {
                    b.Navigation("OrderDatail");
                });

            modelBuilder.Entity("E_Shop.Models.Product", b =>
                {
                    b.Navigation("CategoryToProduct");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("E_Shop.Models.Users", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
