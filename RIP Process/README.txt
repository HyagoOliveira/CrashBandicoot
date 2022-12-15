 --- Processo de Extração dos Assets do jogo Crash Bandicoot Mobile ---

Para qualquer jogo feito em Unity, o processo ideal de extração e importação dos models, textures e animations para um novo projeto é:
 	- Importar primeiramente SOMENTE o modelo (junto com seus bones)
 	- Importar as textures desse modelo e criar os materials
 	- Importar as animações individuais desse modelo (ou somente as quais vc vai usar)

 A pasta \com.king.crash\Android\obb\com.king.crash\assets contém todos os assets do jogo.

 (O tutorial a seguir voltado somente para o jogo mobile Crash on the run. Outros jogos possuim diferentes metodologias.) 

 Use o programa AssetStudio para extrair qualquer asset dessa pasta seguindo os passos:

 1) Abrindo o AssetStudio
 	- Abra o AssetStudio executando o \AssetStudio\AssetStudioGUI.exe
 	- Selecione File > Load Folder
 	- Selecione a pasta \com.king.crash_1.170.29\assets\
 	- Espere carregar todos os assets

  2) Extraindo modelo em T-Pose
 	- Dentro do Asset Studio:
 	 	- Vá na coluna Search Hierarchy
 		- Procure por 'ani_' + nome do modelo + '_def_tPose'
 			- Ex: 'ani_crash_def_tPose'
 		- Selecione o toggle do root desse GO para selecionar todos os filhos
		- Vá em Model > Exported Selected objects (split)
		- Selecione uma pasta para extração. Ex: \RIP Process\Assets
	
	- A pasta onde os arquivos foram exportados será aberta automaticamente
	- O arquivo fbx exportado conterá as meshes e os bones desse modelo
	
	- Dentro do Unity:
 		- Importe o fbx
 		- Na aba de Rig, selecione Generic como o type e crie um avatar usando esse modelo
 			- Caso seja uma modelo de skin alternativa, use o avatar do modelo original

 2) Extraindo Textures do modelo 
 	- Dentro do Asset Studio:
 	 	- Vá na coluna Search Hierarchy
 		- Procure por 'prefab_' + nome do modelo + '_def_tPose'
 			- Ex: 'prefab_crash_def_tPose'
 		- Selecione o toggle do root desse GO para selecionar todos os filhos
		- Vá em Model > Exported Selected objects (split)
		- Selecione uma pasta para extração. Ex: \RIP Process\Assets
	
	- A pasta onde os arquivos foram exportados será aberta automaticamente
	- Algumas textures serão exportadas
	
	- Dentro do Unity:
 		- Importe as textures
 		- Crie um material com as textures e aplique no aba de Materials do modelo

3) Extraindo Animation Clips
	- Dentro do Asset Studio:
		- Vá na coluna Asset List
 		- Filtre somente por animações em Filter Type > AnimationClips 		
 		- Procure por 'ani_' + nome do modelo + '_def_' + nome da animação
 			- Ex: 'ani_crash_def_idle'
 	 	- Vá na coluna Search Hierarchy
 	 	- Procure pelo nome da animação na coluna Scene Hierarchy
 		- Selecione o GO clicando no seu toggle
 		- Volte na aba Asset List e selecione uma ou mais animações
		- Vá em Model > Exported Selected objects (split) + selected animations clips
		- Selecione uma pasta para extração. Ex: \RIP Process\Assets
		- Aguarde o termino do processo. Isso pode demorar dependendo da quantidade de animações selecionadas
	
	- A pasta onde os arquivos foram exportados será aberta automaticamente
	- O arquivo fbx exportado conterá as meshes e os bones desse modelo
	
	- Dentro do Unity:
 		- Importe o fbx
 		- Em Rig desse modelo, é importante selecionar Generic como o type
 		- Você pode visualizar as animações na aba Animations
 			- habilite Import Animations
 			- Arraste o modelo dessa animação para a tela de Preview
 		- Em Hierarchy, expanda o modelo. Vc verá todas as animações dentro desse arquivo.
 		- Selecione todas essas animações e aperte Ctrl + D. Elas vão ser copiadas para fora do modelo fbx
 		- Vc pode deletar o arquivo fbx contento todas as animações

4) Extrair somente as textures
	- Vá na coluna Asset List
	- Filtre somente por textures em Filter Type > Texture2D
	- Filtre pelo personagem pesquisando por o seu nome. Ex: crash
	- Selecione e veja a texture na tela de preview
	- Clique na texture com o botão direito e selecione Exported selected assets
	- Selecione uma pasta para extração. Ex: \RIP Process\Assets
	- A pasta onde os arquivos foram exportados será aberta automaticamente
	- Importe as textures pro Unity