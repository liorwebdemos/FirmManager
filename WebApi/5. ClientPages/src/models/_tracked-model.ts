import { Type } from "class-transformer";

export abstract class TrackedModel
{
  /**  */
  @Type(() => Date)
  public createdDate?: Date;

  /**  */
  public createdUserIp: string;

  /**  */
  @Type(() => Date)
  public updatedDate?: Date;

  /**  */
  public updatedUserIp: string;
}
