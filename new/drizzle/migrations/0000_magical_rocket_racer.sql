CREATE SCHEMA "auth";
--> statement-breakpoint
CREATE SCHEMA "ticket";
--> statement-breakpoint
CREATE TABLE "auth"."localUser" (
	"userId" text NOT NULL,
	"password" text NOT NULL,
	CONSTRAINT "localUser_userId_password_pk" PRIMARY KEY("userId","password")
);
--> statement-breakpoint
CREATE TABLE "auth"."attribute" (
	"id" text PRIMARY KEY NOT NULL,
	"description" text
);
--> statement-breakpoint
CREATE TABLE "auth"."attributeToRole" (
	"attributeId" text NOT NULL,
	"roleId" text NOT NULL,
	CONSTRAINT "attributeToRole_attributeId_roleId_pk" PRIMARY KEY("attributeId","roleId")
);
--> statement-breakpoint
CREATE TABLE "auth"."deniedAttributeForUser" (
	"userId" text NOT NULL,
	"attributeId" text NOT NULL,
	CONSTRAINT "deniedAttributeForUser_userId_attributeId_pk" PRIMARY KEY("userId","attributeId")
);
--> statement-breakpoint
CREATE TABLE "auth"."extraAttributeForUser" (
	"userId" text NOT NULL,
	"attributeId" text NOT NULL,
	CONSTRAINT "extraAttributeForUser_userId_attributeId_pk" PRIMARY KEY("userId","attributeId")
);
--> statement-breakpoint
CREATE TABLE "auth"."role" (
	"id" text PRIMARY KEY NOT NULL,
	"name" text NOT NULL,
	"description" text,
	CONSTRAINT "role_name_unique" UNIQUE("name")
);
--> statement-breakpoint
CREATE TABLE "auth"."roleToUser" (
	"roleId" text NOT NULL,
	"userId" text NOT NULL,
	CONSTRAINT "roleToUser_roleId_userId_pk" PRIMARY KEY("roleId","userId")
);
--> statement-breakpoint
CREATE TABLE "auth"."resetToken" (
	"tokenHash" text NOT NULL,
	"userId" text NOT NULL,
	"expiresAt" timestamp NOT NULL,
	CONSTRAINT "resetToken_tokenHash_userId_expiresAt_pk" PRIMARY KEY("tokenHash","userId","expiresAt"),
	CONSTRAINT "resetToken_tokenHash_unique" UNIQUE("tokenHash")
);
--> statement-breakpoint
CREATE TABLE "auth"."session" (
	"id" text PRIMARY KEY NOT NULL,
	"userId" text NOT NULL,
	"expiresAt" timestamp NOT NULL
);
--> statement-breakpoint
CREATE TABLE "auth"."user" (
	"id" text PRIMARY KEY NOT NULL,
	"email" text NOT NULL,
	"firstName" text NOT NULL,
	"lastName" text NOT NULL,
	"joinDate" timestamp NOT NULL,
	"leaveDate" timestamp,
	"createdAt" timestamp DEFAULT now() NOT NULL,
	"updatedAt" timestamp DEFAULT now() NOT NULL,
	CONSTRAINT "user_email_unique" UNIQUE("email")
);
--> statement-breakpoint
CREATE TABLE "ticket"."ticket" (
	"id" text PRIMARY KEY NOT NULL,
	"userId" text,
	"reason" text NOT NULL,
	"content" text NOT NULL,
	"createdAt" text
);
--> statement-breakpoint
CREATE TABLE "ticket"."ticketReply" (
	"id" text PRIMARY KEY NOT NULL,
	"userId" text NOT NULL,
	"ticketId" text NOT NULL,
	"content" text NOT NULL,
	"createdAt" timestamp NOT NULL
);
--> statement-breakpoint
ALTER TABLE "auth"."localUser" ADD CONSTRAINT "localUser_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."attributeToRole" ADD CONSTRAINT "attributeToRole_attributeId_attribute_id_fk" FOREIGN KEY ("attributeId") REFERENCES "auth"."attribute"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."attributeToRole" ADD CONSTRAINT "attributeToRole_roleId_role_id_fk" FOREIGN KEY ("roleId") REFERENCES "auth"."role"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."deniedAttributeForUser" ADD CONSTRAINT "deniedAttributeForUser_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."deniedAttributeForUser" ADD CONSTRAINT "deniedAttributeForUser_attributeId_attribute_id_fk" FOREIGN KEY ("attributeId") REFERENCES "auth"."attribute"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."extraAttributeForUser" ADD CONSTRAINT "extraAttributeForUser_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."extraAttributeForUser" ADD CONSTRAINT "extraAttributeForUser_attributeId_attribute_id_fk" FOREIGN KEY ("attributeId") REFERENCES "auth"."attribute"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."roleToUser" ADD CONSTRAINT "roleToUser_roleId_role_id_fk" FOREIGN KEY ("roleId") REFERENCES "auth"."role"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."roleToUser" ADD CONSTRAINT "roleToUser_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."resetToken" ADD CONSTRAINT "resetToken_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "auth"."session" ADD CONSTRAINT "session_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "ticket"."ticket" ADD CONSTRAINT "ticket_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "ticket"."ticketReply" ADD CONSTRAINT "ticketReply_userId_user_id_fk" FOREIGN KEY ("userId") REFERENCES "auth"."user"("id") ON DELETE no action ON UPDATE no action;--> statement-breakpoint
ALTER TABLE "ticket"."ticketReply" ADD CONSTRAINT "ticketReply_ticketId_ticket_id_fk" FOREIGN KEY ("ticketId") REFERENCES "ticket"."ticket"("id") ON DELETE no action ON UPDATE no action;