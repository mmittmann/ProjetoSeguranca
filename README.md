ProjetoSeguranca
================

Projeto acadêmico da cadeira de segurança de software

========================================================================================================================
<b>Especificações</b>

O projeto de G1 consiste em uma atividade prática que envolve a pesquisa e o desenvolvimento de um software e a produção de um artigo científico.
O objeto é um sistema para gerenciamento seguro de senhas, que aplicará os principais conceitos estudados na disciplina de segurança de sistemas de informação.

O software deve conter, no mínimo, as seguintes funcionalidades: 
<ul>
  <li>1) Tela de verificação de senhas fortes, avaliando o nível de segurança (fraca, média ou forte) da senha informada;
    As regras mínimas para o verificador pró-ativo de senhas são: 
    Regra Ponderação Fraca Média Forte 
    <ul>
      <li>1.1 – Tamanho da senha 20% até 3 caracteres entre 4 e 8 caracteres acima de 8 caracteres </li>
      <li>1.2 – Tipos de caracteres 20% não contém no mínimo: 
       <ul>
         <li>- 1 letra maiúscula</li> 
         <li>- 1 letra minúscula</li> 
         <li>- 1 dígito numérico </li>
         <li>- 1 sinal de pontuação ou símbolo especial</li> 
         <li>- contém no mínimo: - 1 letra maiúscula </li>
         <li>- 1 letra minúscula </li>
         <li>- 1 dígito numérico </li>
         <li>- 1 sinal de pontuação ou símbolo especial </li>
       </ul>
     </li>
     <li>1.3 – Dicionário 20% consta no dicionário (no mínimo 100 termos em língua portuguesa, variados tamanhos)
      <ul><li>	- não consta no dicionário (no mínimo 100 termos em língua portuguesa, variados tamanhos)</li></ul>
    </li>
    <li>1.4 – Sequências e repetições alfanuméricas:
      <ul>
        <li>20% contém sequência ou repetição de até 3 caracteres em</li>
        <li>contém sequência ou repetição de 2</li>
        <li>não contém sequência ou repetição de</li>
        <li>qualquer parte da senha (Ex.: 123 ou 222)</li>
        <li>caracteres  em qualquer parte da senha (Ex.: ab ou 12)</li>
        <li>caracteres  em qualquer parte da senha</li>
      </ul>
    </li>
    <li>1.5 – Datas 20% contém padrão de data no formato ddmmaaaa (Ex.: 12051990)
      contém padrão de data no formato ddmmaa (Ex.: 120590)
      não contém padrão de data numérico
    </li>
  </ul>
  <small>Observação 2: Caso haja um mesmo percentual de probabilidade, considerar o nível inferior. Exemplo: 40% Forte, 40%      Média, 20% Fraca. Considerar neste caso, a senha Média.</small>
</li>
<li>2) Tela de geração de senhas aleatórias, com validação de senha forte, com comprimento mínimo de 10 caracteres;
  <li>
    <li>3) Tela de login, com autenticação do usuário principal (senha master, que deve ser cadastrada no primeiro acesso e criptografada com um método de chave privada). A senha deve ser consistida com campo de repetir senha e validada como senha forte (aplicando funcionalidade 2). A senha não deve ficar exposta quando digitada (usar campo password);
      <li>
        <li>4) Tela de gerenciamento de senhas, possibilitando o cadastro, consulta, alteração e exclusão de senhas, utilizando criptografia de chave privada (método diferente do usado na funcionalidade 3). Os campos a serem armazenados são: nome do sistema, nome do usuário e senha. Deve-se implementar a cifragem e decifragem das senhas;
          <li>
            <li>5) Tela de backup/restore do banco de senhas, gerando um arquivo único, criptografado com chave privada, contendo todas as senhas armazenadas. A chave secreta deve ser gerada aleatoriamente pelo sistema ou informada pelo usuário (não pode ser hardcoding ou gravada em banco);
              <li>
                <li>6) Tela de compartilhamento de senhas 
                  (apenas algumas senhas selecionadas que serão compartilhadas com outro usuário), 
                  utilizando assinatura digital (ver etapas do protocolo de assinatura digital) 
                  [criptografia e autenticidade de chave pública (usar RSA) e verificação de integridade do arquivo (usar uma função de hash)]. 
                  As senhas a serem cifradas e assinadas digitalmente deverão estar em texto claro e seguindo o layout padrão csv (campos separados por “;”).
                  O layout a ser utilizado: “aplicação;usuário;senha”. Exemplo: “Gmail;abcd@gmail.com;12345”. 
                  Observação 3: O sistema deverá ter no mínimo:
                  <ul><li>1) 3 métodos criptográficos de chave privada (o primeiro deve ser a cifra de
                    César, implementado pelo aluno, mais 2 métodos - que podem ser classes
                    disponíveis na API da linguagem ou obtidas na internet);   
                  </li>
                  <li>
                    2) 1 método
                    criptográfico de chave pública (deve ser o RSA, totalmente implementado pelo
                    aluno, com aritmética modular e exponenciação binária);   
                  </li>
                  <li>
                    3) 1 função hash
                    (MD-5).  Etapas do protocolo de assinatura digital Pré-requisitos: - Tanto
                    remetente quanto destinatário devem ter gerado seus pares de chaves usando o
                    método RSA (todo o método implementado pelo aluno); - Ambos tenham conhecimento
                    da chave pública um do outro e vice-versa (opcionalmente as chaves podem ficar
                    armazenadas na aplicação para automatizar a aplicação do protocolo); - Usar 3
                    dígitos para cada caractere da tabela ASCII. Por exemplo, para a letra A,
                    deve-se usar o numérico 065); - Usar a função hash MD-5 (128 bits). Do lado do
                    remetente: 
                    <ul>
                      <li>1. Selecionar senhas a serem compartilhadas com o destinatário; 
                      </li>
                      <li>2.Decifrar as senhas selecionadas com a chave secreta (criptografia simétrica) do
                        remetente, obtendo a relação de senhas em texto claro; 
                      </li>
                      <li>3. Gerar o csv (campos
                        separadas por ponto e vírgula ";") das senhas em texto claro selecionadas;
                        Exemplo: gmail;ritacampos@gmail.com;xpto123$ hotmail;joaosilva@hotmail.com;1#te#
                      </li>
                      <li>4. Converter o arquivo csv para a codificação numérica utilizando a tabela
                        ASCII; 
                      </li>
                      <li>5. Cifrar a codificação numérica utilizando a chave privada do remetente;
                      </li>
                      <li>6. Cifrar o resultado do item 5 utilizando a chave pública do destinatário; 
                      </li>
                      <li>7.Gerar o código hash do arquivo cifrado item 6 acima (usando MD5 = 128 bits),
                        gerar arquivo com o código hash gerado; 8. Transmitir os arquivos para o
                        destinatário (arquivo criptogrado e arquivo com assinatura hash), separadamente.
                      </li>
                    </ul>
                    <ul>
                    Do lado do destinatário: 
                    <li>1. Gerar o código hash do arquivo criptogrado recebido;</li>
                    <li>2. Validar se o código hash gerado no item 1 acima é igual ao código hash obtido
                    no arquivo com assinatura hash; </li>
                    <li>3. Caso esteja íntegro, decifrar o arquivo
                    recebido utilizando a chave privada do destinatário; </li>
                    <li>4. Decifrar o resultado do
                    item 3 acima utilizando a chave pública do remetente;></li>
                    <li>5. Converter o arquivo em codificação numérica para alfanumérico utilizando a tabela ASCII (texto claro); </li>
                    <li>6. importar a lista de senhas do arquivo csv decifrado, criptografando com a cifra simétrica do destinatário.</li>
                  </ul>
                  </li></ul>
                </li>
              </ul>

              <b>Artigo<b>
                Além do software, deverá ser escrito um artigo científico, seguindo o template da SBC, contendo, no máximo, 4 páginas.
                O artigo deve seguir a seguinte estruturação: - Título (compacto, uma linha) - Resumo (um parágrafo, não precisa abstract) - Introdução (dois parágrafos contextualizando o tema/solução) - Trabalhos relacionados (abordar/comparar dois trabalhos semelhantes) - Tema principal (abordar os temas principais e o software desenvolvido) - Conclusão (destacar as principais conclusões obtidas) - Referências (principais fontes de pesquisa)
                Observações gerais: - O trabalho pode ser realizado em duplas; - A linguagem de programação é de livre escolha, portanto, o sistema pode ser desenvolvido para desktop, web ou mobile; - A persistência dos dados também é de livre escolha, pode-se utilizar banco de dados, arquivos XML, arquivos texto, etc; - Será concedida uma bonificação de 1 ponto para os alunos que implementarem algum tipo de biometria no software;
                Critérios de avaliação: Artigo cientifico: 20% do Projeto G1 Software: 80% do Projeto G1

                <b>Cronograma de avaliação:</b>

                Item Data Escopo da avaliação Peso 
                1 03/09 Requisito 1 10% Projeto G1
                2 17/09 Requisito 2 10% Projeto G1
                3 01/10 Requisito 3 e Requisito 4 Versão preliminar artigo (até trabalhos relacionados)
                20% Projeto G1 50% Artigo G1
                4 29/10 Requisito 5 10% Projeto G1
                5 12/11 Projeto final completo (Requisitos 1 a 6) Artigo final completo
                50% Projeto G1 50% Artigo G1

