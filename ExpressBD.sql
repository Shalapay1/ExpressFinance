PGDMP  4                     |           ExpressFinanceDB    16.2    16.2 !    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16531    ExpressFinanceDB    DATABASE     �   CREATE DATABASE "ExpressFinanceDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Ukraine.1251';
 "   DROP DATABASE "ExpressFinanceDB";
                postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                pg_database_owner    false            �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   pg_database_owner    false    4            �            1259    16561    balances    TABLE     �   CREATE TABLE public.balances (
    balance_id integer NOT NULL,
    user_id integer,
    balance numeric(10,2) NOT NULL,
    last_updated timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);
    DROP TABLE public.balances;
       public         heap    postgres    false    4            �            1259    16560    balances_balance_id_seq    SEQUENCE     �   CREATE SEQUENCE public.balances_balance_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.balances_balance_id_seq;
       public          postgres    false    219    4            �           0    0    balances_balance_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.balances_balance_id_seq OWNED BY public.balances.balance_id;
          public          postgres    false    218            �            1259    16586    cashback    TABLE     Q  CREATE TABLE public.cashback (
    user_id integer NOT NULL,
    car numeric(10,2) DEFAULT 0.00,
    food numeric(10,2) DEFAULT 0.00,
    clothing numeric(10,2) DEFAULT 0.00,
    total_cashback numeric(10,2),
    car_selected boolean DEFAULT false,
    food_selected boolean DEFAULT false,
    clothing_selected boolean DEFAULT false
);
    DROP TABLE public.cashback;
       public         heap    postgres    false    4            �            1259    16548    transactions    TABLE     �   CREATE TABLE public.transactions (
    user_id integer,
    amount numeric(10,2) NOT NULL,
    transaction_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    transaction_id integer NOT NULL,
    receiver_id integer
);
     DROP TABLE public.transactions;
       public         heap    postgres    false    4            �            1259    16575    transactions_transaction_id_seq    SEQUENCE     �   CREATE SEQUENCE public.transactions_transaction_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.transactions_transaction_id_seq;
       public          postgres    false    217    4            �           0    0    transactions_transaction_id_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.transactions_transaction_id_seq OWNED BY public.transactions.transaction_id;
          public          postgres    false    220            �            1259    16533    users    TABLE     0  CREATE TABLE public.users (
    user_id integer NOT NULL,
    email character varying(100) NOT NULL,
    password character varying(100) NOT NULL,
    user_role character varying(50) NOT NULL,
    card_number character varying(16),
    cashback numeric(10,2) DEFAULT 0,
    fop character varying(255)
);
    DROP TABLE public.users;
       public         heap    postgres    false    4            �            1259    16532    users_user_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.users_user_id_seq;
       public          postgres    false    216    4            �           0    0    users_user_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;
          public          postgres    false    215            ,           2604    16564    balances balance_id    DEFAULT     z   ALTER TABLE ONLY public.balances ALTER COLUMN balance_id SET DEFAULT nextval('public.balances_balance_id_seq'::regclass);
 B   ALTER TABLE public.balances ALTER COLUMN balance_id DROP DEFAULT;
       public          postgres    false    219    218    219            +           2604    16576    transactions transaction_id    DEFAULT     �   ALTER TABLE ONLY public.transactions ALTER COLUMN transaction_id SET DEFAULT nextval('public.transactions_transaction_id_seq'::regclass);
 J   ALTER TABLE public.transactions ALTER COLUMN transaction_id DROP DEFAULT;
       public          postgres    false    220    217            (           2604    16536    users user_id    DEFAULT     n   ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);
 <   ALTER TABLE public.users ALTER COLUMN user_id DROP DEFAULT;
       public          postgres    false    215    216    216            �          0    16561    balances 
   TABLE DATA           N   COPY public.balances (balance_id, user_id, balance, last_updated) FROM stdin;
    public          postgres    false    219   �&       �          0    16586    cashback 
   TABLE DATA           �   COPY public.cashback (user_id, car, food, clothing, total_cashback, car_selected, food_selected, clothing_selected) FROM stdin;
    public          postgres    false    221   '       �          0    16548    transactions 
   TABLE DATA           f   COPY public.transactions (user_id, amount, transaction_date, transaction_id, receiver_id) FROM stdin;
    public          postgres    false    217   Z'       �          0    16533    users 
   TABLE DATA           `   COPY public.users (user_id, email, password, user_role, card_number, cashback, fop) FROM stdin;
    public          postgres    false    216   b)       �           0    0    balances_balance_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.balances_balance_id_seq', 4, true);
          public          postgres    false    218            �           0    0    transactions_transaction_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public.transactions_transaction_id_seq', 46, true);
          public          postgres    false    220            �           0    0    users_user_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.users_user_id_seq', 7, true);
          public          postgres    false    215            9           2606    16567    balances balances_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.balances
    ADD CONSTRAINT balances_pkey PRIMARY KEY (balance_id);
 @   ALTER TABLE ONLY public.balances DROP CONSTRAINT balances_pkey;
       public            postgres    false    219            ;           2606    16593    cashback cashback_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public.cashback
    ADD CONSTRAINT cashback_pkey PRIMARY KEY (user_id);
 @   ALTER TABLE ONLY public.cashback DROP CONSTRAINT cashback_pkey;
       public            postgres    false    221            7           2606    16578    transactions transactions_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.transactions
    ADD CONSTRAINT transactions_pkey PRIMARY KEY (transaction_id);
 H   ALTER TABLE ONLY public.transactions DROP CONSTRAINT transactions_pkey;
       public            postgres    false    217            5           2606    16538    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    216            =           2606    16568    balances balances_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.balances
    ADD CONSTRAINT balances_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id);
 H   ALTER TABLE ONLY public.balances DROP CONSTRAINT balances_user_id_fkey;
       public          postgres    false    219    216    4661            >           2606    16594    cashback cashback_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.cashback
    ADD CONSTRAINT cashback_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id);
 H   ALTER TABLE ONLY public.cashback DROP CONSTRAINT cashback_user_id_fkey;
       public          postgres    false    4661    216    221            <           2606    16555 &   transactions transactions_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.transactions
    ADD CONSTRAINT transactions_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id);
 P   ALTER TABLE ONLY public.transactions DROP CONSTRAINT transactions_user_id_fkey;
       public          postgres    false    4661    216    217            �   Q   x�����0�7Taa�$H-�_�~��g) ρ9��l�*3!�G��l���R!�\�|my8:�s�rg�^��7���      �   ;   x�3�4�30@'�@����!9N#��1�0Eș�k1�3��AD!�Ȧ� ec���� �?      �   �  x�}��q�0E��*܀9x��
�{))�Ė4�/���KBH�1��������߄��=�䓐��E	�(t�+�?v(|'4�{��?^bO�>=[�.ݨ/�̟R�eF���)��p�_���J����Cg��K9��U�R��Js�.�	������u�Ȧ����CwҪ���;�9I:%�,�IKuU��[���#�tl�������H���*��$tA���d��������{F����B{�d.����q\s��qV�t�QV֥R���Bz�q��A�υ��2���� �F�S�찯'j<�/���
��;��<밯�� U������C�NR-D�����"��N3ٹ�>��2��L����r��N�t�1`;�7����bW�l��C��Ev��b+_X����$�9�{��E�k){�L<���A��
�i|b&S:V�������^�
����xn�ֵ2�˃�����T�0�      �   �   x�uαn�0����}��|���UELHe�	�I
Q�\�ڪ��=C�y#A)T����K�A�e^�^t�vx\�:/�Ĕ�;fv_wG�?��|f���>�ߞO���d(H)G�8�kJ�(r���menZ�m�U�"�h�H
1�������'��������(e�c�-a��l]��f�%�$��z�jL�$��������rM�ᚁP܇ˀ1vq9g,     