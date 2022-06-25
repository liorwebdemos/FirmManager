import { TrackedModel } from "models";

/**
 * 
 */
export class DepartmentModel extends TrackedModel
{
  /**  */
  public id: number;

  /**  */
  public title: string;

  /**  */
  public description: string;

  /**  */
  public isActive?: boolean;
}
