INSERT INTO clientes (id, nome)
VALUES
    (1, 'Secretaria Municipal de Administração'),
    (2, 'João da Silva'),
    (3, 'Empresa Exemplo Ltda.');

INSERT INTO marcacoes (id_mar, nome_mar)
VALUES
    (1, 'Urgente'),
    (2, 'Revisado'),
    (3, 'Fiscal');

INSERT INTO etapas (id_etapa, nome_etapa, descricao_etapa)
VALUES
    (1, 'Análise documental', 'Conferência dos documentos do processo.'),
    (2, 'Parecer técnico', 'Avaliação técnica do pedido.'),
    (3, 'Decisão', 'Registro da decisão administrativa.');

INSERT INTO processos (
    id_pro,
    numero_pro,
    data_pro,
    interessado_pro,
    assunto_pro,
    descricao_pro,
    situacao_pro,
    created_at,
    id_cli_pro
)
VALUES
    (
        1,
        '2026/000001',
        '2026-10-27',
        'João da Silva',
        'Solicitação de licença',
        'Solicitação de licença para atividade comercial.',
        'Aberto',
        '2026-10-27 08:00:00.000000',
        2
    ),
    (
        2,
        '2026/000002',
        '2026-10-28',
        'Empresa Exemplo Ltda.',
        'Renovação de autorização',
        'Renovação de autorização de funcionamento.',
        'Em análise',
        '2026-10-28 09:30:00.000000',
        3
    ),
    (
        3,
        '2026/000003',
        '2026-10-29',
        'Secretaria Municipal de Administração',
        'Revisão cadastral',
        'Revisão dos dados cadastrais do órgão.',
        'Concluído',
        '2026-10-29 10:15:00.000000',
        1
    );

INSERT INTO processos_marcacoes (marcacao_id, processo_id)
VALUES
    (1, 1),
    (2, 1),
    (3, 2),
    (2, 3);

INSERT INTO processo_etapa (
    processo_id,
    etapa_id,
    ordem,
    data_inicio,
    data_conclusao,
    status,
    observacao
)
VALUES
    (
        1,
        1,
        1,
        '2026-10-27 09:00:00.000000',
        '2026-10-28 15:00:00.000000',
        'Concluída',
        'Documentação conferida e aprovada.'
    ),
    (
        1,
        2,
        2,
        '2026-10-29 08:30:00.000000',
        NULL,
        'Em andamento',
        'Parecer aguardando análise do responsável.'
    ),
    (
        1,
        3,
        3,
        NULL,
        NULL,
        'Pendente',
        'Será iniciada após a conclusão do parecer técnico.'
    ),
    (
        2,
        1,
        1,
        '2026-10-28 10:00:00.000000',
        NULL,
        'Em andamento',
        'Documentos recebidos para conferência.'
    ),
    (
        3,
        1,
        1,
        '2026-10-29 11:00:00.000000',
        '2026-10-29 16:00:00.000000',
        'Concluída',
        'Cadastro conferido.'
    ),
    (
        3,
        2,
        2,
        '2026-10-30 09:00:00.000000',
        '2026-10-30 14:00:00.000000',
        'Concluída',
        'Parecer emitido.'
    ),
    (
        3,
        3,
        3,
        '2026-10-31 09:00:00.000000',
        '2026-10-31 10:00:00.000000',
        'Concluída',
        'Decisão registrada.'
    );

COMMIT;

-- Consultas de conferência.
SELECT * FROM clientes ORDER BY id;
SELECT * FROM marcacoes ORDER BY id_mar;
SELECT * FROM etapas ORDER BY id_etapa;
SELECT * FROM processos ORDER BY id_pro;
SELECT * FROM processos_marcacoes ORDER BY processo_id, marcacao_id;
SELECT * FROM processo_etapa ORDER BY processo_id, ordem;

-- Consulta detalhada do fluxo de cada processo.
SELECT
    p.id_pro,
    p.numero_pro,
    e.id_etapa,
    e.nome_etapa,
    pe.ordem,
    pe.data_inicio,
    pe.data_conclusao,
    pe.status,
    pe.observacao
FROM processos p
INNER JOIN processo_etapa pe ON pe.processo_id = p.id_pro
INNER JOIN etapas e ON e.id_etapa = pe.etapa_id
ORDER BY p.id_pro, pe.ordem;
