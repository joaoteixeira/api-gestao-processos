CREATE TABLE clientes (
    id INT NOT NULL AUTO_INCREMENT,
    nome LONGTEXT NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE marcacoes (
    id_mar INT NOT NULL AUTO_INCREMENT,
    nome_mar LONGTEXT NOT NULL,
    PRIMARY KEY (id_mar)
);

CREATE TABLE etapas (
    id_etapa INT NOT NULL AUTO_INCREMENT,
    nome_etapa LONGTEXT NOT NULL,
    descricao_etapa LONGTEXT NULL,
    PRIMARY KEY (id_etapa)
);

CREATE TABLE processos (
    id_pro INT NOT NULL AUTO_INCREMENT,
    numero_pro LONGTEXT NOT NULL,
    data_pro DATE NOT NULL,
    interessado_pro LONGTEXT NOT NULL,
    assunto_pro LONGTEXT NOT NULL,
    descricao_pro LONGTEXT NULL,
    situacao_pro LONGTEXT NOT NULL,
    created_at DATETIME(6) NOT NULL,
    id_cli_pro INT NULL,
    PRIMARY KEY (id_pro),
    FOREIGN KEY (id_cli_pro) REFERENCES clientes (id)
);

CREATE TABLE processos_marcacoes (
    marcacao_id INT NOT NULL,
    processo_id INT NOT NULL,
    PRIMARY KEY (marcacao_id, processo_id),
    FOREIGN KEY (marcacao_id) REFERENCES marcacoes (id_mar) ON DELETE CASCADE,
    FOREIGN KEY (processo_id) REFERENCES processos (id_pro) ON DELETE CASCADE
);

CREATE TABLE processo_etapa (
    processo_id INT NOT NULL,
    etapa_id INT NOT NULL,
    ordem INT NOT NULL,
    data_inicio DATETIME(6) NULL,
    data_conclusao DATETIME(6) NULL,
    status VARCHAR(30) NOT NULL,
    observacao VARCHAR(1000) NULL,
    PRIMARY KEY (processo_id, etapa_id),
    FOREIGN KEY (processo_id) REFERENCES processos (id_pro) ON DELETE CASCADE,
    FOREIGN KEY (etapa_id) REFERENCES etapas (id_etapa) ON DELETE CASCADE
);
