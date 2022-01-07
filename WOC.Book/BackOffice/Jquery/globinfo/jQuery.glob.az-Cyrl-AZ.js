(function($) {
    var cultures = $.cultures,
        en = cultures.en,
        standard = en.calendars.standard,
        culture = cultures["az-Cyrl-AZ"] = $.extend(true, {}, en, {
        name: "az-Cyrl-AZ",
        englishName: "Azeri (Cyrillic, Azerbaijan)",
        nativeName: "Азәрбајҹан (Азәрбајҹан)",
        language: "az-Cyrl",
        numberFormat: {
            ',': " ",
            '.': ",",
            percent: {
                pattern: ["-n%","n%"],
                ',': " ",
                '.': ","
            },
            currency: {
                pattern: ["-n $","n $"],
                ',': " ",
                '.': ",",
                symbol: "ман."
            }
        },
        calendars: {
            standard: $.extend(true, {}, standard, {
                '/': ".",
                firstDay: 1,
                days: {
                    names: ["Базар","Базар ертәси","Чәршәнбә ахшамы","Чәршәнбә","Ҹүмә ахшамы","Ҹүмә","Шәнбә"],
                    namesAbbr: ["Б","Бе","Ча","Ч","Ҹа","Ҹ","Ш"],
                    namesShort: ["Б","Бе","Ча","Ч","Ҹа","Ҹ","Ш"]
                },
                months: {
                    names: ["Јанвар","Феврал","Март","Апрел","Мај","Ијун","Ијул","Август","Сентјабр","Октјабр","Нојабр","Декабр",""],
                    namesAbbr: ["Јан","Фев","Мар","Апр","Мај","Ијун","Ијул","Авг","Сен","Окт","Ноя","Дек",""]
                },
                monthsGenitive: {
                    names: ["јанвар","феврал","март","апрел","мај","ијун","ијул","август","сентјабр","октјабр","нојабр","декабр",""],
                    namesAbbr: ["Јан","Фев","Мар","Апр","мая","ијун","ијул","Авг","Сен","Окт","Ноя","Дек",""]
                },
                AM: null,
                PM: null,
                patterns: {
                    d: "dd.MM.yyyy",
                    D: "d MMMM yyyy",
                    t: "H:mm",
                    T: "H:mm:ss",
                    f: "d MMMM yyyy H:mm",
                    F: "d MMMM yyyy H:mm:ss",
                    M: "d MMMM",
                    Y: "MMMM yyyy"
                }
            })
        }
    }, cultures["az-Cyrl-AZ"]);
    culture.calendar = culture.calendars.standard;
})(jQuery);