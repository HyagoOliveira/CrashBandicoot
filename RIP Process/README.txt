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
 	- Selecione a pasta \com.king.crash_[VERSÃO DO JOGO]\assets\
 	- Espere carregar todos os assets

 2) Extrair modelo + textures + animations em um único arquivo FBX
 	- Vá na coluna Search Hierarchy
 	- Procure por 'prefab_' + nome do modelo + '_def_tPose'
 		- Ex: 'prefab_crash_def_tPose'
 	- Clique no enter para executar a pesquisa
	- Selecione o toogle do root desse gameobject
	- Vá em Model > Exported Selected objects (split)
	- Selecione uma pasta para extração. Ex: \RIP Process\Assets
	- Dependendo da scene que esse modelo estava, algumas ou muitas animações virão e o processo de extração pode demorarar por causa disso
	- A pasta onde os arquivos foram exportados será aberta automaticamente
	- Importe somente as textures pro Unity e crie um material com elas

3) Extrair somente as textures
	- Vá na coluna Asset List
	- Filtre somente por textures em Filter Type > Texture2D
	- Filtre pelo personagem pesquisando por o seu nome. Ex: crash
	- Selecione e veja a texture na tela de preview
	- Clique na texture com o botão direito e selecione Exported selected assets
	- Selecione uma pasta para extração. Ex: \RIP Process\Assets
	- A pasta onde os arquivos foram exportados será aberta automaticamente
	- Importe as textures pro Unity

 4) Processo de extração somente do modelo (junto com os bones)
 	- Vá na coluna Asset List
 	- Filtre somente por meshes em Filter Type > Mesh
 	- Filtre pelo personagem pesquisando por o seu nome. Ex: crash
 	- Selecione e veja o modelo na tela de preview
 	- Clique no modelo com o botão direito e selecione Go to scene hierarchy
 	- Selecione o toogle do root desse gameobject
 	- Vá em Model > Exported Selected objects (split)
 	- Selecione uma pasta para extração. Ex: \RIP Process\Assets
 	- O arquivo fbx exportado conterá a mesh e os bones desse modelo
 	- Exporte esse arquivo para o Unity 
 	- Aplique o material com as textures desse modelo
 	- Em Rig desse modelo, é importante selecionar Generic como o type e criar um avatar usando esse modelo

 5) Processo de extração das animações
 	- Importe para o Unity o modelo completo gerado pelo passo 1
 	- Em Rig desse modelo, é importante selecionar Generic como o type e criar um avatar usando o avatar do modelo do passo 4
 	- Você pode visualizar as animações na aba Animations
 	- Em Hierarchy, expanda o modelo. Vc verá todas as animações dentro desse arquivo.
 	- Selecione todas essas animações e aperte Ctrl + D. Elas vão ser copiadas para fora do modelo fbx
 	- Vc pode deletar esse arquivo contento todas as animações
 	- Vc pode usar os arquivos de animações puras dentro dos Animator Controllers

  6) Processo de extração de uma animação em específico
 	- Selecione a coluna Asset List
 	- Filtre somente por animações em Filter Type > AnimationClips
 	- Filtre pela animações pesquisando por o seu nome. Ex: idle
 	- Clique na animação com o botão direito e selecione Go to scene hierarchy
 	- Se ele não conseguir encontrar automaticamente vc terá que pesquisar manualmente
 		- Copie o nome da animação e procure na coluna Scene Hierarchy
 	- Selecione o toogle do root desse gameobject
 	- Selecione as animações na coluna de Asset List
 	- Vá em Model > Exported Selected objects (split) + selected animations clips
 	- Selecione uma pasta para extração. Ex: \RIP Process\Assets
 	- O fbx exportado será o modelo + bones + animações que você selecionou
 	- Importe esse arquivo para o Unity
 	- Siga a partir da linha 2 do passo 5 para concluir o processo de importação dessas animações para o Unity


 7) Extraindo animações Crash
 	- Vá na coluna Scene Hiearchy e procure por "ani_crash_def_tPose"
 	- Selecione o toggle desse GameObject
 	- Vá na coluna Asset List
 	- Filtre somente por animations em Filter Type > AnimatioClip
 	- Procure e selecione sua animação, por exemplo: ani_crash_def_idle (é possivel selecionar mais de uma)
 	- Vá em Model > Exported Selected objects (split) + selected animations clips 