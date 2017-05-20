use [ToujjarDatabase-20170327162519]

-- Id:26, pass = 1234 -- 81dc9bdb52d04dc20036dbd8313ed055
Update Voitures set kilometrage=N'10' collate Arabic_CI_AS where Id = 16 ;
select Id,password,trader_name,trader_facebook,trader_instagram,color,car_shape,prix,marque,Modele,ville,EstNeuf,kilometrage,carburant,BoiteDeVitesse,
       Email,phone,temps,img_count
from voitures;-- where password = '202cb962ac59075b964b07152d234b70';
--where Id = 20;  --827ccb0eea8a706c4c34a16891f84e7b