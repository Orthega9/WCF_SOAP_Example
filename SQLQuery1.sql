CREATE VIEW V_Pelicula
AS 
SELECT        dbo.Pelicula.*, dbo.Genero.*
FROM            dbo.Genero INNER JOIN
                         dbo.Pelicula ON dbo.Genero.IdGenero = dbo.Pelicula.Genero					