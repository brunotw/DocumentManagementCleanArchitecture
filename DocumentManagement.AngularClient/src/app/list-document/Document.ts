export class Document
{
    id: number;
    fileName: string;
    fileExtension: string;
    documentBase64: string;
    viewableExtensions =  ['.png', '.jpeg', '.webp', '.jpg'];

    get isViewable()
    {
        return this.viewableExtensions.includes(this.fileExtension.toLowerCase());
    }
}