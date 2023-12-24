using Estates.Data.Enum;
using Estates.Models;
using Microsoft.AspNetCore.Identity;

namespace Estates.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Flats.Any())
                {
                    context.Flats.AddRange(new List<Flat>()
                    {
                        new Flat()
                        {
                            Title = "Hamovniki",
                            Image = "https://cdn-p.cian.site/images/1832973673-4.jpg",
                            Description = "В клубном доме Highline 1 проекта Luzhniki Collection в Хамовниках продаётся коллекционная премиальная квартира с 2 спальнями площадью 86,5 м2 на 17 этаже.\r\nКоллекция двенадцати клубных домов в частном парке на берегу Москва-реки у входа в легендарный олимпийский комплекс \"Лужники\".",
                            FlatCategory = FlatCategory.Twolevel,
                            Price = 86098000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Хамовники",
                                City = "Moscow",
                                State = "RF"
                            }
                         },
                        new Flat()
                        {
                            Title = "Luzhniki collection",
                            Image = "https://cdn-p.cian.site/images/38/504/561/novostroyka-moskva-2y-neopalimovskiy-pereulok-1654058354-4.jpg",
                            Description = "Клубный особняк премиум-класса в престижном районе Хамовники, в 10 минутах ходьбы от Саввинской набережной.",
                            FlatCategory = FlatCategory.Maisonettes,
                            Price = 147900000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Хамовники, 2-й Неопалимовский пер.",
                                City = "Moscow",
                                State = "RF"
                            }
                        },
                       new Flat()
                        {
                            Title = "Luzhniki collection",
                            Image = "https://cdn-p.cian.site/images/1933902934-4.jpg",
                            Description = "В клубном доме Highline 1 проекта Luzhniki Collection в Хамовниках продаётся коллекционная премиальная квартира с 1 спальней площадью 55 м2 на 9 этаже.",
                            FlatCategory = FlatCategory.Maisonettes,
                            Price =47809000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Хамовники, Коллекция Лужники жилой комплекс",
                                City = "Moscow",
                                State = "RF"
                            }
                         },
                        new Flat()
                        {
                            Title = "DUO (Дуо)",
                            Image = "https://cdn-p.cian.site/images/1933636094-4.jpg",
                            Description = "Светлая квартира с окнами, выходящими на Водоотводный канал с фонтанами, Воскресенскую церковь",
                            FlatCategory = FlatCategory.Purposebuilt,
                            Price = 108560000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Якиманка, Софийская наб",
                                City = "Moscow",
                                State = "RF"
                            }
                         },
                        new Flat()
                        {
                            Title = "ЖК «Luzhniki Collection",
                            Image = "https://cdn-p.cian.site/images/12/229/961/1699222145-4.jpg",
                            Description = "В клубном доме Highline 1 проекта Luzhniki Collection в Хамовниках продаётся коллекционная премиальная квартира с 2 спальнями площадью 92,2 м2 на 8 этаже.",
                            FlatCategory = FlatCategory.Converted,
                            Price =75365000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Хамовники, Коллекция Лужники жилой комплекс",
                                City = "Moscow",
                                State = "RF"
                            }
                         },
                        new Flat()
                        {
                            Title = "ЖК «Хамовники 12»",
                            Image = "https://cdn-p.cian.site/images/1901769724-4.jpg",
                            Description = "Продается квартира общей площадью 103,22 кв.м в клубном доме de-luxe класса \"Хамовники 12\", расположенном в историческом центре Москвы.",
                            FlatCategory = FlatCategory.Twolevel,
                            Price = 166307805,
                            Address = new Address()
                            {
                                Street = " ЦАО, р-н Хамовники, пер. 1-й Тружеников, 12",
                                City = "Moscow",
                                State = "RF"
                            }
                         },
                        new Flat()
                        {
                            Title = "ЖК «Magnum (Магнум)»",
                            Image = "https://cdn-p.cian.site/images/1892404239-4.jpg",
                            Description = "Продаются апартаменты c одной спальней в клубном доме MAGNUM. В апартаментах выполнена предчистовая отделка Whitebox с видом в тихий двор.",
                            FlatCategory = FlatCategory.Twolevel,
                            Price = 75690000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Хамовники, ул. Усачева, 9",
                                City = "Moscow",
                                State = "RF"
                            }
                         },
                        new Flat()
                        {
                            Title = "ЖК «Коллекция клубных особняков Ильинка 3/8»",
                            Image = "https://cdn-p.cian.site/images/1869809316-4.jpg",
                            Description = "\"Ильинка 3/8\" - cамая близкая к Кремлю и Красной площади коллекция клубных особняков. Ранее в этой исторической локации проживали представители царских сословий.",
                            FlatCategory = FlatCategory.Twolevel,
                            Price = 152790000,
                            Address = new Address()
                            {
                                Street = " ЦАО, р-н Тверской, Ильинка 3/8 жилой комплекс",
                                City = "Moscow",
                                State = "RF"
                            }
                         },
                        new Flat()
                        {
                            Title = "ЖК «Коллекция клубных особняков Ильинка 3/8»",
                            Image = "https://cdn-p.cian.site/images/1869809356-4.jpg",
                            Description = "\"Ильинка 3/8\" - cамая близкая к Кремлю и Красной площади коллекция клубных особняков. Ранее в этой исторической локации проживали представители царских сословий.",
                            FlatCategory = FlatCategory.Twolevel,
                            Price = 149550000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Тверской, Ильинка 3/8 жилой комплекс",
                                City = "Moscow",
                                State = "RF"
                            }
                         },

                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(new List<Room>()
                    {
                        new Room()
                        {
                            Title = "Комната, 62/18 м²",
                            Image = "https://cdn-p.cian.site/images/28/031/521/komnata-moskva-stremyannyy-pereulok-1251308250-4.jpg",
                            Description = "комната в 3-х комн.кв, сдается только врачу, или программисту который умеет печатать. В других комнатах проживает семья из 3-х человек, все необходимое для проживания имеется",
                            RoomCategory = RoomCategory.Hall,
                            Price =10000,
                            Address = new Address()
                            {
                                Street = "ЦАО, р-н Замоскворечье, Стремянный пер., 9",
                                City = "Moscow",
                                State = "RF"
                            }
                        },
                        new Room()
                        {
                            Title = "Комната, 48/16 м²",
                            Image = "https://cdn-p.cian.site/images/komnata-moskva-domostroitelnaya-ulica-1934579264-4.jpg",
                            Description = "Сдам 1 комнату Одной женщине если будет чистота и порядок В 2 х комнатной квартире От метро Говорово 10 минут пешей доступности Также можно доехать 10 минут на транспорте от метро Юго западная МЦД  Киевская Пр кт Вернадского Кунцевская  Теплый стан  !",
                            RoomCategory = RoomCategory.Hall,
                            Price = 8000,
                            Address = new Address()
                            {
                                Street = "ЗАО, р-н Солнцево, Домостроительная ул., 3",
                                City = "Moscow",
                                State = "RF"
                            }
                        },

                        new Room()
                        {
                            Title = "Комната, 56,7/15 м²",
                            Image = "https://cdn-p.cian.site/images/komnata-moskva-nikitinskaya-ulica-1749908367-4.jpg",
                            Description = "Сдается изолированная комната. Косметический ремонт. В комнате современная мебель: кровать, стол, встроенный шкаф-купе, зеркало с полочками, стулья, ТВ, сушилка для белья, высокоскоростной интернет  с  wi-fi, отдельный холодильник, микроволновая печь.",
                            RoomCategory = RoomCategory.Hall,
                            Price= 15500,
                            Address = new Address()
                            {
                                Street = "ВАО, р-н Северное Измайлово, Никитинская ул., 31К1",
                                City = "Moscow",
                                State = "RF"
                            }
                        },

                        new Room()
                        {
                            Title = "Комната, 54/12 м²",
                            Image = "https://cdn-p.cian.site/images/60/487/861/1687840615-4.jpg",
                            Description = "Сдается комната в 2-х комнатной квартире, одной женщине. в 5 минутах от метро Рязанский проспект.  В комнате есть все необходимое для проживания : кровать, шкаф, кресло, стол, выход на застекленный балкон. Санузел раздельный, стиральная машинка имеется. На кухне гарнитур, холодильник, телевизор.",
                            RoomCategory = RoomCategory.Hall,
                            Price = 18000,
                            Address = new Address()
                            {
                                Street = "ЮВАО, р-н Рязанский, 1-я Новокузьминская ул., 22К1",
                                City = "Moscow",
                                State = "RF"
                            }
                        },

                        new Room()
                        {
                            Title = "Комната, 74/11 м²",
                            Image = "https://cdn-p.cian.site/images/komnata-moskva-bulvar-dmitriya-donskogo-1920172804-4.jpg",
                            Description = "Сдается на длительный срок комната в трехкомнатной квартире. В соседней комнате проживает одна неблагополучная женщина.\r\nГотовы сделать временную регистрацию",
                            RoomCategory = RoomCategory.Hall,
                            Price =15000,
                            Address = new Address()
                            {
                                Street = "ЮЗАО, р-н Северное Бутово, бул. Дмитрия Донского, 9К1",
                                City = "Moscow",
                                State = "RF"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "dmitrylvov",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
