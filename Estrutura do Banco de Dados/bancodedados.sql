CREATE DATABASE bancodedados;

CREATE sequence seq_usuario start 12;
CREATE sequence seq_mensagem start 13;
CREATE sequence seq_dadosseguranca start 8;
CREATE sequence seq_post start 54;
CREATE sequence seq_comentario start 67;
CREATE sequence seq_notificacao start 56; 
CREATE sequence seq_sobre start 3;

CREATE TABLE Usuario (
                id_Usuario INTEGER NOT NULL DEFAULT NEXTVAL('seq_usuario'),
                NomeUsuario VARCHAR(50) NOT NULL,
                NicknameUsuario VARCHAR(20) NOT NULL UNIQUE,
                SenhaUsuario VARCHAR(30) NOT NULL,
                EmailUsuario VARCHAR(30) NOT NULL UNIQUE,
		LinkFoto VARCHAR(200),
		PRIMARY KEY (id_Usuario)
);

CREATE TABLE Mensagem (
  		id_mensagem integer NOT NULL DEFAULT nextval('seq_mensagem'),
  		contentmensagem character varying NOT NULL,
  		visualizadomensagem boolean NOT NULL,
  		datamensagem timestamp without time zone NOT NULL DEFAULT now(),
  		PRIMARY KEY (id_mensagem)
);


CREATE TABLE FollowUsuario (
                id_Usuario INTEGER NOT NULL,
                Usuario_id_Usuario INTEGER NOT NULL,
                DataFollow TIMESTAMP without TIME zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
                CONSTRAINT id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario),
		CONSTRAINT Usuario_id_Usuario FOREIGN KEY (Usuario_id_Usuario) REFERENCES Usuario (id_Usuario),
		PRIMARY KEY (id_Usuario, Usuario_id_Usuario)
);


CREATE TABLE DadosSeguranca (
                id_DadosSeguranca INTEGER NOT NULL DEFAULT NEXTVAL('seq_dadosseguranca'),
                id_Usuario INTEGER NOT NULL UNIQUE,
                EmailRecuperacao VARCHAR(30) NOT NULL,
                TelefoneRecuperacao VARCHAR(13) NOT NULL CHECK (char_length(TelefoneRecuperacao) = 13),
		CONSTRAINT id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario),
                PRIMARY KEY (id_DadosSeguranca)
);


CREATE TABLE Post (
                id_Post INTEGER NOT NULL DEFAULT NEXTVAL('seq_post'),
                id_Usuario INTEGER NOT NULL,
                ContentPost VARCHAR NOT NULL,
                DataPostagem TIMESTAMP without TIME zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
		lat double precision,
  		lon double precision,
                CONSTRAINT id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario),
                PRIMARY KEY (id_Post)
);


CREATE TABLE Comentario (
                id_Comentario INTEGER NOT NULL DEFAULT NEXTVAL('seq_comentario'),
                id_Post INTEGER NOT NULL,
                id_UsuarioRemetente INTEGER NOT NULL,
                DataComentario TIMESTAMP without TIME zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
		Comentariocontent VARCHAR NOT NULL,
		CONSTRAINT id_Post FOREIGN KEY (id_Post) REFERENCES Post (id_Post),
		CONSTRAINT id_UsuarioRemetente FOREIGN KEY (id_UsuarioRemetente) REFERENCES Usuario (id_Usuario),
                PRIMARY KEY (id_Comentario)
);


CREATE TABLE Notificacao (
                id_Notificacao INTEGER NOT NULL DEFAULT NEXTVAL('seq_notificacao'),
                id_Usuario INTEGER NOT NULL,
                Usuario_id_Usuario INTEGER NOT NULL,
                ds_Acao VARCHAR NOT NULL,
                DataAcao TIMESTAMP without TIME zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
		CONSTRAINT id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario),
		CONSTRAINT Usuario_id_Usuario FOREIGN KEY (Usuario_id_Usuario) REFERENCES Usuario (id_Usuario),
                PRIMARY KEY (id_Notificacao)
);


CREATE TABLE Sobre (
                id_Sobre INTEGER NOT NULL DEFAULT NEXTVAL('seq_sobre'),
                id_Usuario INTEGER NOT NULL UNIQUE,
                DataNascimento TIMESTAMP without TIME zone NOT NULL,
                Genero VARCHAR(15) CHECK(Genero in ('Masculino', 'Feminino', 'Outros')),
                Relacionamento VARCHAR(15),
                Biografia VARCHAR,
		CONSTRAINT id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario),
                PRIMARY KEY (id_Sobre)
);


CREATE TABLE usuariomensagem (
		id_usuarioremetente INTEGER NOT NULL,
		id_usuariodestinatario INTEGER NOT NULL,
		id_mensagem INTEGER NOT NULL,
		CONSTRAINT id_usuarioremetente FOREIGN KEY (id_usuarioremetente) REFERENCES usuario (id_usuario),
		CONSTRAINT id_usuariodestinatario FOREIGN KEY (id_usuariodestinatario) REFERENCES usuario (id_usuario),
		CONSTRAINT id_mensagem FOREIGN KEY (id_mensagem) REFERENCES mensagem (id_mensagem),
		PRIMARY KEY (id_usuarioremetente, id_usuariodestinatario, id_mensagem)
);

--Insere Usuario
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (1, 'João Paulo Bráulio', '@uaijoaopaulo', '123', 'jpbc1998@gmail.com', 'https://i.imgur.com/Pd7Lc5k.jpg');
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (2, 'unNamed', '@unnamed', '123', 'suporte.unnamed@gmail.com', 'https://i.imgur.com/0QEPNLa.png');
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (3, 'Gabriel Alves', '@gabrielalves', '123', 'gabrielalves@gmail.com', 'http://images.citysearch.net/assets/imgdb/merchant/2012/10/16/0/mzwBhcgZ81.jpeg');
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (4, 'Juliana Passos', '@julianapassos', '123', 'julianapassos@gmail.com', 'https://i.imgur.com/XfEhe8X.jpghttps://i.imgur.com/XfEhe8X.jpg');
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (5, 'Pedro Carneiro', '@pedrocarneiro', '123', 'pedrocarneiro@gmail.com', NULL);
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (6, 'Gustavo Henrique', '@gustavoghdd', '123', 'gustavohenrique@gmail.com', 'https://instagram.fplu7-1.fna.fbcdn.net/vp/0e0962fc87c1ebb9ed6a8e279bf85820/5BB41011/t51.2885-15/e35/22581991_1755984571080955_8513500275963592704_n.jpg');
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (7, 'Lucas Porto', '@lucasfporto', '123', 'lucasporto@gmail.com', 'https://i.imgur.com/HoDhNXI.png');
INSERT INTO public.usuario (id_usuario, nomeusuario, nicknameusuario, senhausuario, emailusuario, linkfoto) VALUES (11, 'André Cancella ', '@andrecancella', '123', 'siscancella@gmail.com', 'https://i.imgur.com/byIMZeX.jpg');

--Insere Mensagens
INSERT INTO public.mensagem (id_mensagem, contentmensagem, visualizadomensagem, datamensagem) VALUES (4, 'Opa, tudo bem?', true, '2018-05-27 00:22:04.974413');
INSERT INTO public.mensagem (id_mensagem, contentmensagem, visualizadomensagem, datamensagem) VALUES (5, 'Tudo, e você?', false, '2018-05-27 00:24:11.102202');
INSERT INTO public.mensagem (id_mensagem, contentmensagem, visualizadomensagem, datamensagem) VALUES (6, 'oi', true, '2018-05-27 00:53:07.982142');
INSERT INTO public.mensagem (id_mensagem, contentmensagem, visualizadomensagem, datamensagem) VALUES (7, 'opa, iai', true, '2018-05-27 00:54:30.597079');
INSERT INTO public.mensagem (id_mensagem, contentmensagem, visualizadomensagem, datamensagem) VALUES (11, 'né', true, '2018-06-11 01:06:50.428586');
INSERT INTO public.mensagem (id_mensagem, contentmensagem, visualizadomensagem, datamensagem) VALUES (12, 'sei lá ', true, '2018-06-11 01:08:18.013339');

--Insere Usuarios Seguidores
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (2, 1, '2018-05-25 01:26:23.166376');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (3, 2, '2018-05-28 20:03:51.303143');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (4, 3, '2018-05-29 05:30:24.702365');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (1, 2, '2018-05-29 19:42:29.403602');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (4, 1, '2018-06-02 04:31:59.208449');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (3, 4, '2018-06-02 04:38:46.736286');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (1, 6, '2018-06-03 20:22:13.884755');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (1, 4, '2018-06-09 09:25:21.787086');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (11, 4, '2018-06-12 10:23:19.496456');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (1, 11, '2018-06-12 11:15:36.719389');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (11, 1, '2018-06-12 11:16:57.869423');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (3, 1, '2018-06-13 04:24:32.045377');
INSERT INTO public.followusuario (id_usuario, usuario_id_usuario, datafollow) VALUES (1, 3, '2018-06-13 04:48:02.013573');

--Insere dados de seguranca
INSERT INTO public.dadosseguranca (id_dadosseguranca, id_usuario, emailrecuperacao, telefonerecuperacao) VALUES (1, 1, 'jpbraulio@live.com', '5538997455797');

--Insere Post
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (14, 2, 'Programa unNamed', '2018-05-25 01:27:01.564568', NULL, NULL);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (15, 2, 'Criado por João Paulo Bráulio, @uaijoaopaulo', '2018-05-25 01:27:38.165481', NULL, NULL);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (16, 2, 'Não esqueçam sua senha!', '2018-05-25 01:51:42.645125', NULL, NULL);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (20, 1, 'talvez...
', '2018-05-25 17:29:27.286061', NULL, NULL);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (22, 1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '2018-05-25 21:04:58.957391', NULL, NULL);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (25, 1, 'Tudo indo conforme as expectativas...', '2018-05-29 04:41:26.669547', NULL, NULL);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (18, 2, 'Não Usem Dougras crianças!', '2018-05-25 02:07:01.404084', -16.3547373, -46.898281099999998);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (24, 3, 'Ta bem?', '2018-05-28 02:28:27.406404', -16.347180099999999, -46.906102099999998);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (26, 2, 'Cada dia melhor!  ~eu acho', '2018-05-29 04:44:50.383241', -16.3756941, -46.894868099999997);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (29, 4, 'De boas na lagoa', '2018-06-02 03:26:36.909182', -16.354878100000001, -46.898187100000001);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (36, 1, 'Preguiça, mds', '2018-06-03 17:11:04.962445', -16.375221700000001, -46.897996399999997);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (37, 6, 'next, next, next, finish.', '2018-06-03 19:51:52.642206', -16.3600481, -46.902574100000002);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (38, 7, '#drone #dji #mavic #mavicair #mavicpro #s8 #s8photography #sansumg #gopro #sky #ready #clouds #nature #nofilter #nofilterneeded', '2018-06-03 19:55:13.811097', -16.363880099999999, -46.842088099999998);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (40, 4, 'UNICÓRNIOS!', '2018-06-07 14:26:25.79287', -16.367441800000002, -46.896575400000003);
INSERT INTO public.post (id_post, id_usuario, contentpost, datapostagem, lat, lon) VALUES (39, 6, '"Simples né?"', '2018-06-02 20:03:56.314133', -16.359202100000001, -46.901550100000001);

--Insere Comentarios
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (5, 15, 1, '2018-05-27 23:58:38.945759', 'it''s me, Mario!');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (6, 25, 2, '2018-05-29 04:42:03.396283', 'Que bom!');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (7, 26, 1, '2018-05-29 04:45:13.836246', 'vamos ver até onde vamos né');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (8, 26, 3, '2018-05-29 04:45:37.352126', 'TÁ TOP !');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (9, 24, 4, '2018-05-29 05:31:29.992217', 'Toooooooooooooooooo');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (10, 22, 1, '2018-06-03 08:50:25.296572', 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (11, 29, 1, '2018-06-03 08:57:18.582081', 'Hu3');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (12, 37, 1, '2018-06-05 06:24:26.548709', 'next, next, next, finish!');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (13, 40, 1, '2018-06-07 14:28:10.020629', 'são só cavalos cornos, calmaa');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (14, 22, 1, '2018-06-09 01:30:50.633118', 'aaaaaaaaaaaaaaaaa');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (28, 22, 1, '2018-06-11 00:17:42.050222', 'aaaaaaaaa');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (29, 22, 3, '2018-06-11 00:20:06.704498', 'AAaaaaaaaaaaaaaaaa');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (35, 40, 11, '2018-06-12 10:24:21.550368', 'São criaturas que só tem 1 olho? pq são UNI CORNEAs');
INSERT INTO public.comentario (id_comentario, id_post, id_usuarioremetente, datacomentario, comentariocontent) VALUES (50, 22, 1, '2018-06-13 02:44:53.308635', 'AAAAAAAAAAAAAA');

--Insere Notificacoes
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (1, 2, 1, 'Seguiu você!', '2018-05-25 20:11:36.562479');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (12, 3, 2, 'Seguiu você!', '2018-05-28 20:03:51.942138');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (17, 4, 3, 'Seguiu você!', '2018-05-29 05:30:25.042359');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (18, 1, 2, 'Seguiu você!', '2018-05-29 19:42:30.222593');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (21, 4, 1, 'Seguiu você!', '2018-06-02 04:31:59.838441');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (23, 3, 4, 'Seguiu você!', '2018-06-02 04:38:47.099281');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (25, 1, 6, 'Seguiu você!', '2018-06-03 20:22:15.325738');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (33, 1, 4, 'Seguiu você!', '2018-06-09 09:25:21.797086');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (34, 11, 4, 'Seguiu você!', '2018-06-12 10:23:20.219449');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (35, 1, 11, 'Seguiu você!', '2018-06-12 11:15:37.175382');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (36, 11, 1, 'Seguiu você!', '2018-06-12 11:16:57.898421');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (46, 3, 1, 'Seguiu Você!', '2018-06-13 04:24:32.048766');
INSERT INTO public.notificacao (id_notificacao, id_usuario, usuario_id_usuario, ds_acao, dataacao) VALUES (54, 1, 3, 'Seguiu Você!', '2018-06-13 04:48:02.018719');

--Insere Sobre
INSERT INTO public.sobre (id_sobre, id_usuario, datanascimento, genero, relacionamento, biografia) VALUES (2, 1, '1998-03-11 00:00:00', 'Masculino', 'Solteiro(a)', 'Estudante de Sistemas de Informação da Faculdade CNEC de Unaí-MG ');

--Insere Usuario Mensagem
INSERT INTO public.usuariomensagem (id_usuarioremetente, id_usuariodestinatario, id_mensagem) VALUES (1, 2, 4);
INSERT INTO public.usuariomensagem (id_usuarioremetente, id_usuariodestinatario, id_mensagem) VALUES (2, 1, 5);
INSERT INTO public.usuariomensagem (id_usuarioremetente, id_usuariodestinatario, id_mensagem) VALUES (1, 3, 7);
INSERT INTO public.usuariomensagem (id_usuarioremetente, id_usuariodestinatario, id_mensagem) VALUES (3, 1, 6);
INSERT INTO public.usuariomensagem (id_usuarioremetente, id_usuariodestinatario, id_mensagem) VALUES (1, 2, 11);
INSERT INTO public.usuariomensagem (id_usuarioremetente, id_usuariodestinatario, id_mensagem) VALUES (1, 3, 12);

--Trigger FOLLOW USUARIO

CREATE OR REPLACE FUNCTION followperfil_notificacao()
RETURNS trigger AS $BODY$
BEGIN
IF(TG_OP = 'INSERT') THEN
INSERT INTO notificacao(id_usuario, usuario_id_usuario, ds_acao) VALUES(new.id_usuario, new.usuario_id_usuario, 'Seguiu Você!');
RETURN NEW;
ELSIF(TG_OP = 'DELETE') THEN
DELETE FROM notificacao WHERE id_usuario = old.id_usuario and usuario_id_usuario = old.usuario_id_usuario and ds_acao = 'Seguiu Você!';
RETURN OLD;
END IF;
RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER trigger_Follow_Unfollow
AFTER INSERT OR DELETE ON followusuario
FOR EACH ROW
EXECUTE PROCEDURE followperfil_notificacao();


--Trigger Comentario

CREATE OR REPLACE FUNCTION comentario_notificacao()
RETURNS trigger AS $BODY$
BEGIN
IF(TG_OP = 'INSERT') THEN
INSERT INTO notificacao(id_usuario, usuario_id_usuario, ds_acao) VALUES(new.id_usuarioremetente, (select id_usuario from post where id_post = new.id_post), 'Comentou em sua Postagem!');
RETURN NEW;
ELSIF(TG_OP = 'DELETE') THEN
DELETE FROM notificacao WHERE id_usuario = old.id_usuarioremetente and usuario_id_usuario = (select id_usuario from post where id_post = old.id_post) and ds_acao = 'Comentou em sua Postagem!' and dataacao::timestamp(0) = old.datacomentario::timestamp(0);
RETURN OLD;
END IF;
RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER trigger_Comenta_ExcluiComentario
AFTER INSERT OR DELETE ON comentario
FOR EACH ROW
EXECUTE PROCEDURE comentario_notificacao()


--View de todos os dados dos usuarios

CREATE VIEW vw_todos_dados_usuarios AS
SELECT 
	u.nomeusuario as NomeUsuario,
	u.nicknameusuario as Nickname,
	u.emailusuario as Email,
	s.datanascimento as DataNascimento,
	s.genero as Genero,
	s.relacionamento as Relacionamento, 
	ds.emailrecuperacao as EmailRecuperacaoSenha,	
	ds.telefonerecuperacao as TelefoneRecuperacaoSenha
FROM usuario u 
LEFT JOIN sobre s ON u.id_usuario = s.id_usuario
LEFT JOIN dadosseguranca ds ON u.id_usuario = ds.id_usuario
ORDER BY u.nomeusuario;


--View de quantidade de dados por usuario usuario

CREATE VIEW vw_quantidade_dados_usuarios AS
SELECT 
	u.id_usuario as ID_usuario,
	u.nomeusuario as NomeUsuario,
	u.nicknameusuario as Nickname,
	(select count(*) from post where id_usuario = u.id_usuario) as Qnt_Post,
	(select count(*) from comentario where id_usuarioremetente = u.id_usuario) as Qnt_Comentario,
	(select count(*) from usuariomensagem where id_usuarioremetente = u.id_usuario) as QntMensagem_Enviada, 
	(select count(*) from usuariomensagem where id_usuariodestinatario = u.id_usuario) as QntMensagem_Recebida	
FROM usuario u 
ORDER BY u.id_usuario;

--Conta a quantidade de Post para ser usado na criação do perfil

CREATE OR REPLACE FUNCTION quantidade_Post(integer) RETURNS integer AS $$
DECLARE
id_usuario_informado ALIAS FOR $1;
BEGIN
IF(id_usuario_informado <= 0) THEN
	Raise exception 'usuario não pode ser igual ou menor que 0';
END IF;
RETURN (Select count(*) from post where id_usuario = id_usuario_informado);
END;
$$ LANGUAGE plpgsql;

--Conta a quantidade de Comentarios para ser usado na criação do perfil

CREATE OR REPLACE FUNCTION quantidade_Comentario(integer) RETURNS integer AS $$
DECLARE
id_usuario_informado ALIAS FOR $1;
BEGIN
IF(id_usuario_informado <= 0) THEN
	Raise exception 'usuario não pode ser igual ou menor que 0';
END IF;
RETURN (Select count(*) from comentario where id_usuarioremetente = id_usuario_informado);
END;
$$ LANGUAGE plpgsql;

--Conta a quantidade de Seguidores para ser usado na criação do perfil

CREATE OR REPLACE FUNCTION quantidade_Seguidores(integer) RETURNS integer AS $$
DECLARE
id_usuario_informado ALIAS FOR $1;
BEGIN
IF(id_usuario_informado <= 0) THEN
	Raise exception 'usuario não pode ser igual ou menor que 0';
END IF;
RETURN (Select count(*) from followusuario where usuario_id_usuario = id_usuario_informado);
END;
$$ LANGUAGE plpgsql;

--Conta a quantidade de usuarios que voce segue para ser usado na criação do perfil

CREATE OR REPLACE FUNCTION quantidade_Seguindo(integer) RETURNS integer AS $$
DECLARE
id_usuario_informado ALIAS FOR $1;
BEGIN
IF(id_usuario_informado <= 0) THEN
	Raise exception 'usuario não pode ser igual ou menor que 0';
END IF;
RETURN (Select count(*) from followusuario where id_usuario = id_usuario_informado);
END;
$$ LANGUAGE plpgsql;
