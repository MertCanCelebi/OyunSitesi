
$(document).ready(function () {

    var arrLang = {

        'tr': {

            '0': 'E-mail',
            '1': 'Şifre',
            '2': 'Giriş Yap',
            '3': 'Giriş Sayfası',
            '4': 'Şifreyi Tekrar Giriniz',
            '5': 'Kayıt Ol',
            '6': 'Kayıt',
            '7': 'Hakkında Sayfası',
            '8': 'Hakkımızda',
            '9': 'Öncelikle sitemize hoşgeldiniz.Aşağıda bizim hakkımızda bilgilere sahip olabilirsiniz.İyi gezintiler',
            '10': 'Merhaba,ben Mert Can Çelebi. 20 yaşındayım ve Sakarya Üniversitesinde Bilgisayar Mühendisliği okuyorum.',
            '11': "Mail adresim: mertcancelebi12@gmail.com",
            '12': "Telefon Numaram: 05366354850",
            '13': 'Merhaba,ben Dorukan Uysal. 20 yaşındayım ve Sakarya Üniversitesinde Bilgisayar Mühendisliği okuyorum.',
            '14': 'Mail adresim: dorukanuysal@gmail.com',
            '15': 'Telefon Numaram: 05396855657',
            '16': "Oyun Magazininin Kalbi GameHell'e hoşgeldiniz",
            '17': 'En Çok Okunan 3 oyun',
            '18': 'Yorumlar',
            '19': 'Önceki Yorumlar:',
            '20': 'Senin Yorumun',
            '21': 'Yorum Ekle',
            '22': 'Profil',
            '23': 'İsim Soyisim',
            '24': 'Kaydet',
            '25': 'Yeni Şifre',
            '26': 'Şifre Değiştirildi',
            '27': 'İsim Değiştirildi',
            '28': 'Anasayfa',
            '29': 'Hakkımızda',
            '30': 'Kategoriler',
            '31': 'Admin Paneli',
            '32': 'Kullanıcılar',
            '33': 'Oyunlar',
            '34': 'Yorumlar',
            '35': 'Çıkış',
            '36': 'Kullanıcı Duzenle',
            '37': 'Rol',
            '38': 'Seçiniz',
            '39': 'Kullanici',
            '40': 'Kullanıcı Ekle',
            '41': 'Yeni Kullanıcı',
            '42': 'Düzenle',
            '43': 'Sil',
            '44': 'Yeni Oyun',
            '45': 'Oyun Adı',
            '46': 'Icerik',
            '47': 'Kategori Id',
            '48': 'Oyun Ekle',
            '49': 'Resim',
            '50': 'Oyun Duzenle',
            
        },


        'en': {
            '0': 'E-mail',
            '1': 'Password',
            '2': 'Log in',
            '3': 'Log in Page',
            '4': 'Re-enter Password',
            '5': 'Register',
            '6': 'Register',
            '7': 'About Page',
            '8': 'About Us',
            '9': 'First of all, welcome to our site. You can have information about us below. Have a nice trip.',
            '10': "Hello, I'm Mert Can Celebi.I am 20 years old and I am studying Computer Engineering at Sakarya University.",
            '11': 'My MailAdress: mertcancelebi12@gmail.com',
            '12': 'My Telephone Number: 05366354850 ',
            '13': "Hello, I'm Dorukan Uysal.I am 20 years old and I am studying Computer Engineering at Sakarya University.",
            '14': 'My MailAdress: dorukanuysal@gmail.com',
            '15': 'My Telephone Number: 05396855657 ',
            '16': 'Welcome to GameHell, the Heart of the Gaming Magazine',
            '17': 'Top 3 games',
            '18': 'Comments',
            '19': 'Previous Comments:',
            '20': 'Your Comment',
            '21': 'Add Comment',
            '22': 'Profile',
            '23': "Name Surname",
            '24': 'Save',
            '25': 'New Password',
            '26': 'The password was changed',
            '27': 'The name was changed',
            '28': 'Home Page',
            '29': 'About Us',
            '30': 'Categories',
            '31': 'Admin Panel',
            '32': 'Users',
            '33': 'Games',
            '34': 'Comments',
            '35': 'Log Out',
            '36': 'Edit user',
            '37': 'Role',
            '38': 'Choose',
            '39': 'User',
            '40': 'Add User',
            '41': 'New User',
            '42': 'Edit',
            '43': 'Delete',
            '44': 'New Game',
            '45': 'Game Name',
            '46': 'Content',
            '47': 'Categori Id',
            '48': 'Add Game',
            '49': 'Picture',
            '50': 'Edit Games',

        },


    };



    $('.dropdown-item').click(function () {
        localStorage.setItem('dil', JSON.stringify($(this).attr('id')));
        location.reload();
    });

    var lang = JSON.parse(localStorage.getItem('dil'));

    if (lang == "en") {
        $("#drop_yazı").html("English");
    }
    else {
        $("#drop_yazı").html("Türkçe");

    }

    $('a,h5,p,h1,h2,span,li,button,h3,label').each(function (index, element) {
        $(this).text(arrLang[lang][$(this).attr('key')]);

    });

});
