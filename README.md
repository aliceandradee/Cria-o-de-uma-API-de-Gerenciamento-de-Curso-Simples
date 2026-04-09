# Projeto De Criação API Gerenciamento De Cursos

Atividade feito no curso técnico de Desenvolvimento De Sistemas sobre criação de uma API com funcionalidade para gerenciamento de cursos e com funcionalidade de realizar uma tratativa de erros, visando a qualidade 
e robustez do tratamento de erros e corrigir as falhas que geram no erro 500. Utilizando blocos de tratamentos de exceções (try/catch).

<div align="center">
<img src="imagens/tratativa de erro.png" alt="Descrição" width="800"/>
</div>

A imagem ilustra a implementação solicitada pelo orientador no método Put, onde o sistema devereá realizar uma verificação preventiva no banco de dados antes de confirmar qualquer alteração. Através de um método que será visto logo abaixo no código. Em resumo, essa API tem como funcionalidade comparar o nome enviado com os registros já existentes, garantindo que nenhum outro curso (com ID diferente) possua o mesmo nome; caso a duplicidade seja confirmada, a execução é interrompida e retorna um Erro 500, servindo como uma barreira de segurança que impede a entrada de dados redundantes e garante a integridade da tabela.

---
