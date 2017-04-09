use [SoughDB-20160411134152]
--SELECT name FROM sys.tables ORDER BY name -- Les noms du tables

--select IdVoiture,prix,marque,Modele,ville,kilometrage,carburant,BoiteDeVitesse,
--       Email,phone,temps,color,car_shape,password,trader_name,trader_facebook,
--	   trader_instagram,img_count,EstNeuf
--select IdVoiture,image1,phone
--from Voitures 

--select IdVoiture,trader_name,DATALENGTH(image1) as image1,phone,EstNeuf,color,car_shape
select *
from Voitures
--where Voitures.phone = '41223344'; 


--SELECT distinct t1.IdVoiture,t1.trader_name,t1.phone,t1.marque
--FROM voitures t1
--INNER JOIN voitures t2 ON t1.phone=t2.phone AND t1.IdVoiture <> t2.IdVoiture
--order by t1.phone
--WHERE marque = 'Audi' AND Modele = '100' AND ville = 'Nouadhibou' 
--		AND 
--		(	color = 'white' OR color = 'grey' OR color = 'brown' 
--			OR color = 'black' OR color = 'red' OR color = 'yellow' 
--			OR color = 'green' OR color = 'blue'
--		) 
--		AND 
--		(	car_shape = '4x4' OR car_shape = 'berline' OR car_shape = 'bassin' 
--			OR car_shape = 'break'
--		);
--where ville='Nouakchott';

--Update Voitures           --- SUV, Berline , Break , Pickup
--Set    car_shape='Pickup'
--where IdVoiture=10129;




--select IdVoiture,prix,marque,Modele,ville,kilometrage,carburant,BoiteDeVitesse,
--       Email,phone,temps,color,car_shape,password,trader_name,trader_facebook,
--	   trader_instagram,img_count
--from voitures
--where carburant = 'essance';

/*



select IdVoiture,marque,Modele,ville,car_shape,color
from voitures;

DBCC CHECKIDENT ('Voitures', RESEED, 0)
GO

GO
sp_rename 'OldName','NewName';
GO

GO  
EXEC sp_rename 'Table.oldCol', 'newCol', 'COLUMN';  
GO

informations sur la table
EXEC sp_help Jeus;
*/
