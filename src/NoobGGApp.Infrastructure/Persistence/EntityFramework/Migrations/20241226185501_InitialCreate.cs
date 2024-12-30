using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "application_roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    user_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    normalized_email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false),
                    created_by_user_id = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    zip_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    state = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address_apartment = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tags = table.Column<string>(type: "text", nullable: false),
                    created_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2024, 12, 26, 18, 55, 1, 506, DateTimeKind.Unspecified).AddTicks(7559), new TimeSpan(0, 0, 0, 0, 0))),
                    modified_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_application_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "application_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "application_user_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_application_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "application_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_key = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_application_user_logins_application_users_user_id",
                        column: x => x.user_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "application_user_roles",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_application_user_roles_application_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "application_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_application_user_roles_application_users_user_id",
                        column: x => x.user_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "application_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    login_provider = table.Column<string>(type: "character varying(191)", maxLength: 191, nullable: false),
                    name = table.Column<string>(type: "character varying(191)", maxLength: 191, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_application_user_tokens_application_users_user_id",
                        column: x => x.user_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_mode",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    min_team_size = table.Column<int>(type: "integer", nullable: false),
                    max_team_size = table.Column<int>(type: "integer", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_mode", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_mode_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_rank",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_rank", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_rank_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_regions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2024, 12, 26, 18, 55, 1, 506, DateTimeKind.Unspecified).AddTicks(9452), new TimeSpan(0, 0, 0, 0, 0))),
                    modified_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_regions", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_regions_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false),
                    game_mode_id = table.Column<long>(type: "bigint", nullable: false),
                    game_region_id = table.Column<long>(type: "bigint", nullable: false),
                    min_game_rank_id = table.Column<long>(type: "bigint", nullable: true),
                    max_game_rank_id = table.Column<long>(type: "bigint", nullable: true),
                    min_team_size = table.Column<int>(type: "integer", nullable: false),
                    max_team_size = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    is_microphone_required = table.Column<bool>(type: "boolean", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    owner_id = table.Column<long>(type: "bigint", nullable: false),
                    row_version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lobby", x => x.id);
                    table.ForeignKey(
                        name: "fk_lobby_application_users_creator_id",
                        column: x => x.creator_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_application_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_game_mode_game_mode_id",
                        column: x => x.game_mode_id,
                        principalTable: "game_mode",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_game_rank_max_game_rank_id",
                        column: x => x.max_game_rank_id,
                        principalTable: "game_rank",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lobby_game_rank_min_game_rank_id",
                        column: x => x.min_game_rank_id,
                        principalTable: "game_rank",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lobby_game_regions_game_region_id",
                        column: x => x.game_region_id,
                        principalTable: "game_regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby_event_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lobby_id = table.Column<long>(type: "bigint", nullable: false),
                    event_type = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lobby_event_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_lobby_event_history_application_users_user_id",
                        column: x => x.user_id,
                        principalTable: "application_users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lobby_event_history_lobby_lobby_id",
                        column: x => x.lobby_id,
                        principalTable: "lobby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby_language",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lobby_id = table.Column<long>(type: "bigint", nullable: false),
                    language_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lobby_language", x => x.id);
                    table.ForeignKey(
                        name: "fk_lobby_language_language_language_id",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_language_lobby_lobby_id",
                        column: x => x.lobby_id,
                        principalTable: "lobby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby_message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lobby_id = table.Column<long>(type: "bigint", nullable: false),
                    sender_id = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lobby_message", x => x.id);
                    table.ForeignKey(
                        name: "fk_lobby_message_application_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_message_lobby_lobby_id",
                        column: x => x.lobby_id,
                        principalTable: "lobby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_application_role_claims_role_id",
                table: "application_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "application_roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_application_user_claims_user_id",
                table: "application_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_application_user_logins_user_id",
                table: "application_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_application_user_roles_role_id",
                table: "application_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "application_users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_application_users_email",
                table: "application_users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "application_users",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_game_mode_game_id",
                table: "game_mode",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_rank_game_id",
                table: "game_rank",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_regions_game_id",
                table: "game_regions",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_creator_id",
                table: "lobby",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_game_id",
                table: "lobby",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_game_mode_id",
                table: "lobby",
                column: "game_mode_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_game_region_id",
                table: "lobby",
                column: "game_region_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_max_game_rank_id",
                table: "lobby",
                column: "max_game_rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_min_game_rank_id",
                table: "lobby",
                column: "min_game_rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_owner_id",
                table: "lobby",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_event_history_lobby_id",
                table: "lobby_event_history",
                column: "lobby_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_event_history_user_id",
                table: "lobby_event_history",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_language_language_id",
                table: "lobby_language",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_language_lobby_id",
                table: "lobby_language",
                column: "lobby_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_message_lobby_id",
                table: "lobby_message",
                column: "lobby_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_message_sender_id",
                table: "lobby_message",
                column: "sender_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_role_claims");

            migrationBuilder.DropTable(
                name: "application_user_claims");

            migrationBuilder.DropTable(
                name: "application_user_logins");

            migrationBuilder.DropTable(
                name: "application_user_roles");

            migrationBuilder.DropTable(
                name: "application_user_tokens");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "lobby_event_history");

            migrationBuilder.DropTable(
                name: "lobby_language");

            migrationBuilder.DropTable(
                name: "lobby_message");

            migrationBuilder.DropTable(
                name: "application_roles");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "lobby");

            migrationBuilder.DropTable(
                name: "application_users");

            migrationBuilder.DropTable(
                name: "game_mode");

            migrationBuilder.DropTable(
                name: "game_rank");

            migrationBuilder.DropTable(
                name: "game_regions");

            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
